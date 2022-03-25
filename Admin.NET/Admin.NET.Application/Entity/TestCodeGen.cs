using System;
using SqlSugar;
using System.ComponentModel;
using Admin.NET.Core;
namespace Admin.NET.Application
{
     /// <summary>
     /// 测试代码生成
     /// </summary>
      [SugarTable("test_code_gen")]
      [Description("测试代码生成")]
      public class TestCodeGen  : EntityBase
      {
          /// <summary>
          /// 图像
          /// </summary>
          public long Image { get; set; }
          /// <summary>
          /// 用户
          /// </summary>
          public long User { get; set; }
          /// <summary>
          /// 状态
          /// </summary>
          public bool Status { get; set; }
}	
}