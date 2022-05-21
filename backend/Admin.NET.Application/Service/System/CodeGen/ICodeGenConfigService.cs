﻿using Admin.NET.Core;
using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ICodeGenConfigService
    {
        Task Add(CodeGenConfig input);

        Task DelAndAddList(List<TableColumnOuput> tableColumnOuputList, SysCodeGen codeGenerate);

        Task Delete(long codeGenId);

        Task<SysCodeGenConfig> Detail([FromQuery] CodeGenConfig input);

        Task<List<CodeGenConfig>> List([FromQuery] CodeGenConfig input);

        Task Update(List<CodeGenConfig> inputList);
    }
}