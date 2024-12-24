// Admin.NET 项目的版权、商标、专利和其他相关权利均受相应法律法规的保护。使用本项目应遵守相关法律法规和许可证的要求。
//
// 本项目主要遵循 MIT 许可证和 Apache 许可证（版本 2.0）进行分发和使用。许可证位于源代码树根目录中的 LICENSE-MIT 和 LICENSE-APACHE 文件。
//
// 不得利用本项目从事危害国家安全、扰乱社会秩序、侵犯他人合法权益等法律法规禁止的活动！任何基于本项目二次开发而产生的一切法律纠纷和责任，我们不承担任何责任！

using Admin.Net.Plugin.DingTalk.RequestProxy.BaseTypes;

using System.Text.Json.Serialization;

namespace Admin.Net.Plugin.DingTalk.RequestProxy.User.DTO;

public class RoleListResponse : DingtalkResponseErrorResultRequestId<RoleListResultDomain>
{
}

public class RoleListResultDomain
{
    /// <summary>
    /// 是否还有更多数据
    /// </summary>
    public bool HasMore { get; set; }

    /// <summary>
    /// 角色组列表
    /// </summary>
    public List<OpenRoleGroup> List { get; set; }

    public class OpenRoleGroup
    {
        /// <summary>
        /// 角色组ID
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 角色组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public List<OpenRole> Roles { get; set; }

        public class OpenRole
        {
            /// <summary>
            /// 角色ID
            /// </summary>
            public long Id { get; set; }

            /// <summary>
            /// 角色名称
            /// </summary>
            public string Name { get; set; }
        }
    }
}