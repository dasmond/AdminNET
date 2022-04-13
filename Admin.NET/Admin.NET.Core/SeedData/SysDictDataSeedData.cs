using System;
using System.Collections.Generic;

namespace Admin.NET.Core.SeedData
{
    /// <summary>
    /// 系统字典值表种子数据
    /// </summary>
    public class SysDictDataSeedData : ISqlSugarEntitySeedData<SysDictData>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysDictData> HasData()
        {
            return new[]
            {
                new SysDictData{Id= 26904054364925 ,DictTypeId= 269037953163589 ,Value=  "输入框",Code="Input",Order=100, Remark= "输入框", Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00") },
                new SysDictData{Id= 269709947433285,DictTypeId= 269037953163589,Value= "外键", Code="fk",Order=100, Remark= "外键",  Status= StatusEnum.Enable,CreateTime=DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710006817093,DictTypeId= 269037953163589,Value= "时间选择",Code="DatePicker", Order=100, Remark= "时间选择",Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710248583493,DictTypeId= 269037953163589,Value= "选择器",Code="Select",Order=  100, Remark="选择器",  Status= StatusEnum.Enable,CreateTime=DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710750769477,DictTypeId= 269037953163589,Value= "单选框",Code="RadioGroup",Order=  100, Remark= "单选框", Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710823379269,DictTypeId= 269037953163589,Value= "多选框",Code="Checkbox",Order=  100, Remark= "多选框", Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710898270533,DictTypeId= 269037953163589,Value= "数字输入框",Code="InputNumber",Order=  100, Remark= "数字输入框",Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269710996332869,DictTypeId= 269037953163589,Value= "文本域",Code="InputTextArea",Order=  100, Remark= "文本域", Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269711041397061,DictTypeId= 269037953163589,Value= "上传",Code="Upload",Order=  100, Remark= "上传",Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269711313645893,DictTypeId= 269037953163589,Value= "树选择",Code="ApiTreeSelect",Order=100, Remark= "树选择", Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269711498232133,DictTypeId= 269037953163589,Value= "API选择器", Code="ApiSelect",Order=100, Remark= "从api加载数据源",Status= StatusEnum.Enable,CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 270434376429893,DictTypeId= 269037953163589,Value= "开关",Code="Switch",Order= 100, Remark= "开关",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},

                new SysDictData{Id= 269405027090757,DictTypeId= 269404851347781,Value= "等于",Code="==",Order= 1, Remark= "等于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405158699333,DictTypeId= 269404851347781,Value= "模糊",Code="like",Order= 1, Remark= "模糊",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405249491269,DictTypeId= 269404851347781,Value= "大于",Code=">",Order= 1, Remark= "大于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405410816325,DictTypeId= 269404851347781,Value= "小于",Code="<",Order= 1, Remark= "小于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405489000773,DictTypeId= 269404851347781,Value= "不等于",Code="!=",Order= 1, Remark= "不等于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405554168133,DictTypeId= 269404851347781,Value= "大于等于",Code=">=",Order= 1, Remark= "大于等于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405626069317,DictTypeId= 269404851347781,Value= "小于等于",Code="<=",Order= 1, Remark= "小于等于",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269405691662661,DictTypeId= 269404851347781,Value= "不为空",Code="isNotNull",Order= 1, Remark= "不为空",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},

                new SysDictData{Id= 269407485235525,DictTypeId= 269406747853125,Value= "long",          Code="long",          Order= 1, Remark= "long",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407528223045,DictTypeId= 269406747853125,Value= "string",        Code="string",        Order= 1, Remark= "string",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407589753157,DictTypeId= 269406747853125,Value= "DateTime",      Code="DateTime",      Order= 1, Remark= "DateTime",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407623504197,DictTypeId= 269406747853125,Value= "bool",          Code="bool",          Order= 1, Remark= "bool",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407650124101,DictTypeId= 269406747853125,Value= "int",           Code="int",           Order= 1, Remark= "int",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407798747461,DictTypeId= 269406747853125,Value= "double",        Code="double",        Order= 1, Remark= "double",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407828496709,DictTypeId= 269406747853125,Value= "float",         Code="float",         Order= 1, Remark= "float",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407866655045,DictTypeId= 269406747853125,Value= "decimal",       Code="decimal",       Order= 1, Remark= "decimal",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407908036933,DictTypeId= 269406747853125,Value= "Guid",          Code="Guid",          Order= 1, Remark= "Guid",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269407935918405,DictTypeId= 269406747853125,Value= "DateTimeOffset",Code="DateTimeOffset",Order= 1, Remark= "DateTimeOffset",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},

                new SysDictData{Id= 269419751756101,DictTypeId= 269419660861765,Value= "下载压缩包",Code="1",Order= 1, Remark= "下载压缩包",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
                new SysDictData{Id= 269419781321029,DictTypeId= 269419660861765,Value= "生成到本项目",Code="2",Order= 1, Remark= "生成到本项目",Status= StatusEnum.Enable,   CreateTime= DateTime.Parse("2022-02-10 00:00:00")},
            };
        }
    }
}