using EmployManagementSystemAPIs.Model;

namespace EmployManagementSystemAPIs.Services.SalaryInfoServices
{
    public interface ISalaryInfoServices
    {
        Task<List<SalaryInfo>> GetAllSalaryInfo();
        Task<SalaryInfo> GetSalaryInfoById(int id);
        Task<int> PostSalaryInfo(SalaryInfo salaryinfo);
        Task<int> UpdateSalaryInfo(SalaryInfo salaryinfo);
        Task<int> DeleteSalaryInfo(int Id);
    }
}
