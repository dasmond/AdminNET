using Admin.NET.Core;
using Dapr.Shared;
using Furion;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.DaprEventBus
{
    /// <summary>
    /// Dapr 事件服务接口
    /// </summary>
    [ApiDescriptionSettings(Name = "Dapr 事件服务接口", Order = 200)]
    public class DaprEventService : IDynamicApiController, ITransient
    {
        private readonly SqlSugarRepository<SysLogEx> _sysExLogRep;
        private readonly SqlSugarRepository<SysLogOp> _sysOpLogRep;

        public DaprEventService(SqlSugarRepository<SysLogEx> sysExLogRep,
            SqlSugarRepository<SysLogOp> sysOpLogRep)
        {
            _sysExLogRep = sysExLogRep;
            _sysOpLogRep = sysOpLogRep;
        }


        /// <summary>
        /// 接收错误日志。
        /// 由于使用eventbus转发不会带token,所以去掉验证
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/DaprEvent/AddExLog")]
        [Dapr.Topic("pubsub", nameof(AddExLogEvent))]
        public int AddExLog(AddExLogEvent eventData)
        {
            _sysExLogRep.Insert(new SysLogEx
            {
                ClassName = eventData.ClassName,
                CreateTime = eventData.CreationDate,
                ExceptionMsg = eventData.ExceptionMsg,
                CreateUserId = 0,
                ExceptionName = eventData.ExceptionName,
                MethodName = eventData.MethodName,
                ExceptionSource = eventData.ExceptionSource,
                ParamsObj = eventData.ParamsObj,
                RealName = eventData.RealName,
                StackTrace = eventData.StackTrace,
                UpdateUserId = 0, 
                UpdateTime = DateTime.Now,
                UserName = eventData.UserName,
            });  
            return 1;
        }

        /// <summary>
        /// 接收操作日志
        /// 由于使用eventbus转发不会带token,所以去掉验证
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        [HttpPost("/DaprEvent/AddOpLog")]
        [AllowAnonymous]
        [Dapr.Topic("pubsub", nameof(AddOpLogEvent))]
        public int AddOpLog(AddOpLogEvent eventData)
        {
            _sysOpLogRep.Insert(new SysLogOp
            {
                ClassName = eventData.ClassName,
                CreateTime = eventData.CreationDate,
                MethodName = eventData.MethodName,
                RealName = eventData.RealName,
                Browser = eventData.Browser,
                ElapsedTime = eventData.ElapsedTime,
                Ip = eventData.Ip,
                Location = eventData.Location,
                Os = eventData.Os,
                Param = eventData.Param,
                ReqMethod = eventData.ReqMethod,
                Result = eventData.Result,
                Success = eventData.Success ? YesNoEnum.Y : YesNoEnum.N,
                Url = eventData.Url,
                UpdateUserId=0,
                CreateUserId = 0,
                UpdateTime = DateTime.Now,
                UserName = eventData.UserName,
            });
            return 1;
        }
    }
}
