namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 字典关系输出
    /// </summary>
    public class DictRelationOutput
    {
        public long DataId { get; set; }

        public long DataRelationId { get; set; }

        public long TypeId { get; set; }

        public string DataRelationValue { get; set; }

        public string TypeName { get; set; }
    }
}
