using SqlSugar;
using Admin.NET.Core;
using Admin.NET.Core.Service;

namespace Admin.NET.Application
{
    /// <summary>
    /// 测试生成输出参数
    /// </summary>
    public class TestCodeGenOutput
    {
       /// <summary>
       /// 主键Id
       /// </summary>
       public long Id { get; set; }
    
       /// <summary>
       /// 图像
       /// </summary>
        public long Image { get; set; }
        public MapperSysFileOutput ImageAttachment { get; set; }
    
       /// <summary>
       /// 用户
       /// </summary>
       public long User { get; set; }
       public UserFkSysUserOutput FkUser { get; set; }
    
       /// <summary>
       /// 状态
       /// </summary>
       public bool Status { get; set; }
    
    }
    [SugarTable("sys_user")]
    [NotTable]
    public class UserFkSysUserOutput: EntityBaseId
    {
        public string NickName { get; set; }
    }
}
