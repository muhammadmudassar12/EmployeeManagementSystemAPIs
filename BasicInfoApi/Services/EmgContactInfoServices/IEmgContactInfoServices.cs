using EmployManagementSystemAPIs.Model;

namespace EmployManagementSystemAPIs.Services.EmgContactInfoServices
{
    public interface IEmgContactInfoServices
    {
        Task<List<EmgContactInfo>> GetAllEmgContactInfo();
        Task<EmgContactInfo> GetEmgContactInfoById(int id);
        Task<int> PostEmgContactInfo(EmgContactInfo emgcontactinfo);
        Task<int> UpdateEmgContactInfo(EmgContactInfo emgcontactinfo);
        Task<int> DeleteEmgContactInfo(int Id);
    }
}
