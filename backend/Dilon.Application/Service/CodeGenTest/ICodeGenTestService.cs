using Dilon.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dilon.Application
{
    public interface ICodeGenTestService
    {
        Task Add(AddCodeGenTestInput input);
        Task Delete(DeleteCodeGenTestInput input);
        Task<CodeGenTest> Get([FromQuery] QueryeCodeGenTestInput input);
        Task<dynamic> List([FromQuery] CodeGenTestInput input);
        Task<dynamic> Page([FromQuery] CodeGenTestInput input);
        Task Update(UpdateCodeGenTestInput input);
    }
}