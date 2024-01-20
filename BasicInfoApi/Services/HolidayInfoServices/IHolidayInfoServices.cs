using EmployManagementSystemAPIs.Model;

namespace EmployManagementSystemAPIs.Services.HolidayInfoServices
{
    public interface IHolidayInfoServices
    {
        Task<List<HolidayInfo>> GetAllHolidayInfo();
        Task<HolidayInfo> GetHolidayInfoById(int id);
        Task<int> PostHolidayInfo(HolidayInfo holidayinfo);
        Task<int> UpdateHolidayInfo(HolidayInfo holidayinfo);
        Task<int> DeleteHolidayInfo(int Id);
    }
}
