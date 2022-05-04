 

namespace Dapr.Shared ;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent integrationEvent);
}
