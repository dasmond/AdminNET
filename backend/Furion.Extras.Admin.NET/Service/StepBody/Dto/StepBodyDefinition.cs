using System;
using System.Collections.Generic;

namespace Furion.Extras.Admin.NET.Service.StepBody.Dto
{
    public class StepBodyDefinition
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
       public WorkflowParamDictionary Inputs { get; set; } = new WorkflowParamDictionary();

        public Type StepBodyType { get; set; }
    }
}
