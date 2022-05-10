namespace Admin.NET.Application
{
    public interface IMachineService
    {
        Task<dynamic> GetMachineBaseInfo();

        Task<dynamic> GetMachineNetWorkInfo();

        Task<dynamic> GetMachineUseInfo();
    }
}