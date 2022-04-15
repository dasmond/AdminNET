using SqlSugar;
using Admin.NET.Core;
using Admin.NET.Core.Service;
using System.Collections.Generic;

namespace Admin.NET.Application
{
    /// <summary>
    /// 租户管理输出参数
    /// </summary>
    public class SysTenantOutput
    {
       /// <summary>
       /// Id
       /// </summary>
       public long Id { get; set; }
    
       /// <summary>
       /// 公司名称
       /// </summary>
       public string Name { get; set; }
    
       /// <summary>
       /// 管理员名称
       /// </summary>
       public string AdminName { get; set; }
    
       /// <summary>
       /// 主机
       /// </summary>
       public string Host { get; set; }
    
       /// <summary>
       /// 电子邮箱
       /// </summary>
       public string Email { get; set; }
    
       /// <summary>
       /// 电话
       /// </summary>
       public string Phone { get; set; }
    
       /// <summary>
       /// 数据库连接
       /// </summary>
       public string Connection { get; set; }
    
       /// <summary>
       /// 架构
       /// </summary>
       public string Schema { get; set; }
    
       /// <summary>
       /// 备注
       /// </summary>
       public string Remark { get; set; }
    
    }


}
