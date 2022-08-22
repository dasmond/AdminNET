using Admin.NET.Core;
using Furion;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Models;

namespace Admin.NET.Application
{
    /// <summary>
    /// FurionPersistenceProvider
    /// </summary>
    [AllowAnonymous]
    public class FurionPersistenceProvider : IFurionPersistenceProvider, ISingleton
    {
        private IServiceProvider Services { get; }

        public bool SupportsScheduledCommands => false;

        public FurionPersistenceProvider(IServiceProvider services)
        {
            Services = services;
        }


        public async Task<string> CreateEventSubscription(EventSubscription subscription, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();

            subscription.Id = Guid.NewGuid().ToString();
            var persistable = subscription.ToPersistable();
            await scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>().InsertNowAsync(persistable);
            return subscription.Id;
        }

        public async Task<string> CreateNewWorkflow(WorkflowInstance workflow, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();

            workflow.Id = Guid.NewGuid().ToString();
            var persistable = workflow.ToPersistable();
            await scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>().InsertNowAsync(persistable);
            return workflow.Id;
        }

        public async Task<IEnumerable<string>> GetRunnableInstances(DateTime asAt, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();

            var now = asAt.Ticks;
            var raw = await scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>()
                .Where(x => x.NextExecution.HasValue && (x.NextExecution <= now) && (x.Status == WorkflowStatus.Runnable))
                .Select(x => x.InstanceId)
                .ToListAsync(cancellationToken);

            return raw.Select(s => s.ToString()).ToList();
        }

        public async Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(WorkflowStatus? status, string type, DateTime? createdFrom, DateTime? createdTo, int skip, int take)
        {
            using var scope = Services.CreateScope();

            var query = scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>()
                  .Include(wf => wf.ExecutionPointers)
                  .ThenInclude(ep => ep.ExtensionAttributes)
                  .Include(wf => wf.ExecutionPointers)
                  .AsQueryable();

            if (status.HasValue)
                query = query.Where(x => x.Status == status.Value);

            if (!string.IsNullOrEmpty(type))
                query = query.Where(x => x.WorkflowDefinitionId == type);

            if (createdFrom.HasValue)
                query = query.Where(x => x.CreateTime >= createdFrom.Value);

            if (createdTo.HasValue)
                query = query.Where(x => x.CreateTime <= createdTo.Value);

            var rawResult = await query.Skip(skip).Take(take).ToListAsync();
            List<WorkflowInstance> result = new List<WorkflowInstance>();

            foreach (var item in rawResult)
                result.Add(item.ToWorkflowInstance());

            return result;
        }

        public async Task<WorkflowInstance> GetWorkflowInstance(string Id, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();

            var uid = new Guid(Id);
            var raw = await scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>()
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .FirstAsync(x => x.InstanceId == uid, cancellationToken);

            if (raw == null)
                return null;

            return raw.ToWorkflowInstance();
        }

        public async Task<IEnumerable<WorkflowInstance>> GetWorkflowInstances(IEnumerable<string> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null)
                return new List<WorkflowInstance>();

            using var scope = Services.CreateScope();

            var uids = ids.Select(i => new Guid(i));
            var raw = scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>()
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .Where(x => uids.Contains(x.InstanceId));

            return (await raw.ToListAsync(cancellationToken)).Select(i => i.ToWorkflowInstance());
        }

        public async Task PersistWorkflow(WorkflowInstance workflow, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedWorkflow>>();

            var uid = new Guid(workflow.Id);
            var existingEntity = await rep
                .Where(x => x.InstanceId == uid)
                .Include(wf => wf.ExecutionPointers)
                .ThenInclude(ep => ep.ExtensionAttributes)
                .Include(wf => wf.ExecutionPointers)
                .AsTracking()
                .FirstAsync(cancellationToken);

            var persistable = workflow.ToPersistable(existingEntity);
            await rep.Context.SaveChangesAsync(cancellationToken);
        }

        public async Task TerminateSubscription(string eventSubscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();

            var uid = new Guid(eventSubscriptionId);
            var existing = await rep.AsQueryable().FirstAsync(x => x.SubscriptionId == uid, cancellationToken);
            await rep.DeleteAsync(existing);
            await rep.Context.SaveChangesAsync(cancellationToken);
        }


        public virtual void EnsureStoreExists()
        {
        }

        public async Task<IEnumerable<EventSubscription>> GetSubscriptions(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();

            var raw = await rep
                .Where(x => x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf)
                .ToListAsync(cancellationToken);

            return raw.Select(item => item.ToEventSubscription()).ToList();
        }

        public async Task<string> CreateEvent(Event newEvent, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

            newEvent.Id = Guid.NewGuid().ToString();
            var persistable = newEvent.ToPersistable();
            await rep.InsertNowAsync(persistable);
            return newEvent.Id;
        }

        public async Task<Event> GetEvent(string id, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

            Guid uid = new Guid(id);
            var raw = await rep.AsQueryable().FirstAsync(x => x.EventId == uid, cancellationToken);

            if (raw == null)
                return null;

            return raw.ToEvent();
        }

        public async Task<IEnumerable<string>> GetRunnableEvents(DateTime asAt, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

            var now = asAt;
            var raw = await rep
                .Where(x => !x.IsProcessed)
                .Where(x => x.EventTime <= now)
                .Select(x => x.EventId)
                .ToListAsync(cancellationToken);

            return raw.Select(s => s.ToString()).ToList();
        }

        public async Task MarkEventProcessed(string id, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

            var uid = new Guid(id);
            var existingEntity = await rep
                .Where(x => x.EventId == uid)
                .AsTracking()
                .FirstAsync(cancellationToken);

            existingEntity.IsProcessed = true;
            await rep.Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<string>> GetEvents(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

            var raw = await rep
                .Where(x => x.EventName == eventName && x.EventKey == eventKey)
                .Where(x => x.EventTime >= asOf)
                .Select(x => x.EventId)
                .ToListAsync(cancellationToken);

            return raw.Select(a => a.ToString());
        }

        public async Task MarkEventUnprocessed(string id, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedEvent>>();

                var uid = new Guid(id);
                var existingEntity = await rep
                    .Where(x => x.EventId == uid)
                    .AsTracking()
                    .FirstAsync(cancellationToken);

                existingEntity.IsProcessed = false;
                await rep.Context.SaveChangesAsync(cancellationToken);
        }

        public async Task PersistErrors(IEnumerable<ExecutionError> errors, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedExecutionError>>();

            var executionErrors = errors as ExecutionError[] ?? errors.ToArray();
            if (executionErrors.Any())
            {
                foreach (var error in executionErrors)
                    await rep.InsertAsync(error.ToPersistable());

                await rep.Context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<EventSubscription> GetSubscription(string eventSubscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();

            var uid = new Guid(eventSubscriptionId);
            var raw = await rep.DetachedEntities.FirstOrDefaultAsync(x => x.SubscriptionId == uid, cancellationToken);

            return raw?.ToEventSubscription();
        }

        public async Task<EventSubscription> GetFirstOpenSubscription(string eventName, string eventKey, DateTime asOf, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();
            var raw = await rep.DetachedEntities.FirstOrDefaultAsync(x => x.EventName == eventName && x.EventKey == eventKey && x.SubscribeAsOf <= asOf && x.ExternalToken == null, cancellationToken);

            return raw?.ToEventSubscription();
        }

        public async Task<bool> SetSubscriptionToken(string eventSubscriptionId, string token, string workerId, DateTime expiry, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();

            var uid = new Guid(eventSubscriptionId);
            var existingEntity = await rep.AsQueryable()
                .Where(x => x.SubscriptionId == uid)
                .AsTracking()
                .FirstAsync(cancellationToken);

            existingEntity.ExternalToken = token;
            existingEntity.ExternalWorkerId = workerId;
            existingEntity.ExternalTokenExpiry = expiry;
            await rep.Context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task ClearSubscriptionToken(string eventSubscriptionId, string token, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedSubscription>>();

            var uid = new Guid(eventSubscriptionId);
            var existingEntity = await rep
                .Where(x => x.SubscriptionId == uid)
                .AsTracking()
                .FirstAsync(cancellationToken);

            if (existingEntity.ExternalToken != token)
                throw new InvalidOperationException();

            existingEntity.ExternalToken = null;
            existingEntity.ExternalWorkerId = null;
            existingEntity.ExternalTokenExpiry = null;
            await rep.Context.SaveChangesAsync(cancellationToken);
        }

        public async Task ScheduleCommand(ScheduledCommand command)
        {
            try
            {
                using var scope = Services.CreateScope();
                var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedScheduledCommand>>();

                var persistable = command.ToPersistable();
                await rep.InsertAsync(persistable);
                await rep.Context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }
        }

        public async Task ProcessCommands(DateTimeOffset asOf, Func<ScheduledCommand, Task> action, CancellationToken cancellationToken = default)
        {
            using var scope = Services.CreateScope();
            var rep = scope.ServiceProvider.GetRequiredService<IRepository<PersistedScheduledCommand>>();

            var cursor = rep.Where(x => x.ExecuteTime < asOf.UtcDateTime.Ticks).AsAsyncEnumerable();

            await foreach (var command in cursor)
            {
                try
                {
                    await action(command.ToScheduledCommand());
                    await rep.DeleteAsync(command);
                    await rep.Context.SaveChangesAsync();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}