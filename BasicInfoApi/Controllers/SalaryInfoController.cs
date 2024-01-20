using EmployManagementSystemAPIs.Model;
using EmployManagementSystemAPIs.Services.SalaryInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployManagementSystemAPIs.Controllers
{
    [Route("SalaryInfo/api/")]
    public class SalaryInfoController : Controller
    {        
            private readonly ISalaryInfoServices _salaryinfoServices;
            public SalaryInfoController(ISalaryInfoServices salaryinfoServices)
            {
            _salaryinfoServices = salaryinfoServices;
            }
            [HttpGet()]
            public async Task<IActionResult> GetAllSalaryInfo()
            {
                var salaryinfo = await _salaryinfoServices.GetAllSalaryInfo();
                if (salaryinfo.Count == 0)
                {
                    return NotFound("SalaryInfo not exist");
                }


                return this.Ok(salaryinfo);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetSalaryInfoById(int id)
            {
                var salaryinfo = await _salaryinfoServices.GetSalaryInfoById(id);
                if (salaryinfo == null)
                {
                    return NotFound($"SalaryInfo Id {id} not exist");
                }


                return this.Ok(salaryinfo);
            }
            [HttpPost()]
            public async Task<IActionResult> PostSalaryInfo([FromBody] SalaryInfo salaryinfo)
            {
                try
                {
                    int result = await _salaryinfoServices.PostSalaryInfo(salaryinfo);
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
            public async Task<IActionResult> UpdateSalaryInfo(int id, [FromBody] SalaryInfo salaryinfo)
            {
                try
                {
                    var dbsalaryinfo = await _salaryinfoServices.GetSalaryInfoById(id);
                    if (dbsalaryinfo == null)
                    {
                        return this.NotFound($"SalaryInfo Id {id} not found..");
                    }

                    salaryinfo.Id = id;
                    int result = await _salaryinfoServices.UpdateSalaryInfo(salaryinfo);
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
        public async Task<IActionResult> DeleteSalaryInfo(int id)
        {
            try
            {
                var dbsalaryinfo = await _salaryinfoServices.GetSalaryInfoById(id);
                if (dbsalaryinfo == null)
                {
                    return this.NotFound($"SalaryInfo Id {id} not found..");
                }
                int result = await _salaryinfoServices.DeleteSalaryInfo(id);
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
