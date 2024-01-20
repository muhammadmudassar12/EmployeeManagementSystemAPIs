using EmployManagementSystemAPIs.Model;

namespace EmployManagementSystemAPIs.Services.BasicInfoServices
{
    public interface IBasicInfoServices
    {
        Task<List<BasicInfo>> GetAllBasicInfo();
        Task<BasicInfo> GetBasicInfoById(int id);
        Task<int> PostBasicInfo(BasicInfo basicinfo);
        Task<int> UpdateBasicInfo(BasicInfo basicinfo);
        Task<int> DeleteBasicInfo(int Id);
    }
}
