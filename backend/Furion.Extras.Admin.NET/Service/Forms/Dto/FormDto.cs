namespace Furion.Extras.Admin.NET.Service.Forms.Dto
{
    /// <summary>
    /// 表单输出Dto
    /// </summary>
    public class FormDto
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public FormDto()
        {

        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="formDto"></param>
        public FormDto(FormDto formDto)
        {
            this.Id = formDto.Id;
            this.Title = formDto.Title;
            this.FormJson = formDto.FormJson;
            this.Publish =formDto.Publish;
            this.TypeId = formDto.TypeId;
            this.TypeName = formDto.TypeName;
            this.Version = formDto.Version;
            this.CreatedUserName = formDto.CreatedUserName;
            this.CreatedUserId  = formDto.CreatedUserId;
            this.CreatedTime = formDto.CreatedTime;
            this.NodesList = formDto.NodesList;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="formjson"></param>
        /// <param name="publish"></param>
        /// <param name="typeId"></param>
        /// <param name="typeName"></param>
        /// <param name="version"></param>
        /// <param name="createdUserName"></param>
        /// <param name="createdUserId"></param>
        /// <param name="createdTime"></param>
        /// <param name="nodesList"></param>
        public FormDto(long id,string title,string formjson,bool publish,long typeId,string typeName,int version, string createdUserName,long? createdUserId, DateTimeOffset? createdTime, FormList nodesList)
        {
            this.Id = id;
            this.Title = title;
            this.FormJson = formjson;
            this.Publish = publish;
            this.TypeId = typeId;
            this.TypeName = typeName;
            this.Version = version;
            this.CreatedUserName = createdUserName;
            this.CreatedUserId = createdUserId;
            this.CreatedTime = createdTime;
            this.NodesList = nodesList;
        }

        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///表单标题 不可重复
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// form表单Json
        /// </summary>
        public string FormJson { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool Publish { get; set; }

        /// <summary>
        /// 表单类型ID
        /// </summary>
        public long TypeId { get; set; }

        /// <summary>
        /// 表单类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        public string CreatedUserName { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public long? CreatedUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTimeOffset? CreatedTime { get; set; }


        /// <summary>
        /// 节点列表
        /// </summary>
        public FormList NodesList { get; set; }
    }

    /// <summary>
    /// 表单列表
    /// </summary>
    public class FormList
    {
        /// <summary>
        /// 节点列表
        /// </summary>
        public List<FormNode> List { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public FormConfig Config { get; set; }
    }

    /// <summary>
    /// 表单节点
    /// </summary>
    public class FormNode
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 属性设置
        /// </summary>
	    public FormOptions Options { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Model { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 帮助
        /// </summary>
        public string Help { get; set; }
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// 校验规则
        /// </summary>
		public List<FormRules> Rules { get; set; }
    }

    /// <summary>
    /// 节点属性
    /// </summary>
    public class FormOptions
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
		public string Width { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 帮助信息
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Clearable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MaxLength { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Disabled { get; set; }
    }

    /// <summary>
    /// 校验规则
    /// </summary>
    public class FormRules
    {
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 表单配置
    /// </summary>
    public class FormConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Layout { get; set; }


        public FormLabelCol LabelCol {get;set;}


        public FormWrapperCol WrapperCol { get; set; }


		public bool HideRequiredMark { get; set; }



        public string CustomStyle { get; set; }

    }
    public class FormLabelCol
     {
        public int XS { get; set; }
	    public int SM { get; set; }
        public int MD { get; set; }
        public int LG { get; set; }
        public int XL { get; set; }
        public int XXL { get; set; }
    }
    public class FormWrapperCol
    {
        public int XS { get; set; }
        public int SM { get; set; }
        public int MD { get; set; }
        public int LG { get; set; }
        public int XL { get; set; }
        public int XXL { get; set; }
    }
}
