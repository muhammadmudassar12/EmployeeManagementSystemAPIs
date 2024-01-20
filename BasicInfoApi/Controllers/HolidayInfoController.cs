using EmployManagementSystemAPIs.Model;
using EmployManagementSystemAPIs.Services.HolidayInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployManagementSystemAPIs.Controllers
{
    [Route("HolidayInfo/api/")]
    public class HolidayInfoController : Controller
    {
        private readonly IHolidayInfoServices _holidayinfoServices;
        public HolidayInfoController(IHolidayInfoServices salaryinfoServices)
        {
            _holidayinfoServices = salaryinfoServices;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllSalaryInfo()
        {
            var holidayinfo = await _holidayinfoServices.GetAllHolidayInfo();
            if (holidayinfo.Count == 0)
            {
                return NotFound("HolidayInfo not exist");
            }


            return this.Ok(holidayinfo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHolidayInfoById(int id)
        {
            var holidayinfo = await _holidayinfoServices.GetHolidayInfoById(id);
            if (holidayinfo == null)
            {
                return NotFound($"HolidayInfo Id {id} not exist");
            }


            return this.Ok(holidayinfo);
        }
        [HttpPost()]
        public async Task<IActionResult> PostHolidayInfo([FromBody] HolidayInfo holidayinfo)
        {
            try
            {
                int result = await _holidayinfoServices.PostHolidayInfo(holidayinfo);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHolidayInfo(int id, [FromBody] HolidayInfo holidayinfo)
        {
            try
            {
                var dbholidayinfo = await _holidayinfoServices.GetHolidayInfoById(id);
                if (dbholidayinfo == null)
                {
                    return this.NotFound($"HolidayInfo Id {id} not found..");
                }

                holidayinfo.Id = id;
                int result = await _holidayinfoServices.UpdateHolidayInfo(holidayinfo);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHolidayInfo(int id)
        {
            try
            {
                var dbholidayinfo = await _holidayinfoServices.GetHolidayInfoById(id);
                if (dbholidayinfo == null)
                {
                    return this.NotFound($"HolidayInfo Id {id} not found..");
                }
                int result = await _holidayinfoServices.DeleteHolidayInfo(id);
                if (result > 0)
                    return this.Ok("true");
                else
                    return this.BadRequest("false");

            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }
    }
}
