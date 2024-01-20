
using EmployManagementSystemAPIs.Model;
using EmployManagementSystemAPIs.Services.BasicInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployManagementSystemAPIs.Controllers
{
    [Route("BasicInfo/api/")]
    public class BasicInfoController : Controller
    {              
        private readonly IBasicInfoServices _basicinfoServices;
        public BasicInfoController(IBasicInfoServices basicinfoServices)
        {
            _basicinfoServices = basicinfoServices;
        }
        [HttpGet()]
        public async Task<IActionResult> GetAllBasicInfo()
        {
            var basicinfo = await _basicinfoServices.GetAllBasicInfo();
            if (basicinfo.Count == 0)
            {
                return NotFound("BasicInfo not exist");
            }


            return this.Ok(basicinfo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasicIngfoById(int id)
        {
            var basicinfo = await _basicinfoServices.GetBasicInfoById(id);
            if (basicinfo == null)
            {
                return NotFound($"BasicInfo Id {id} not exist");
            }


            return this.Ok(basicinfo);
        }
        [HttpPost()]
        public async Task<IActionResult> PostBasicInfo([FromBody] BasicInfo basicinfo)
        {
            try
            {
                int result = await _basicinfoServices.PostBasicInfo(basicinfo);
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
        public async Task<IActionResult> UpdateBasicInfo(int id, [FromBody] BasicInfo basicinfo)
        {
            try
            {
                var dbbasicinfo = await _basicinfoServices.GetBasicInfoById(id);
                if (dbbasicinfo == null)
                {
                    return this.NotFound($"BasicInfo Id {id} not found..");
                }

                basicinfo.Id = id;
                int result = await _basicinfoServices.UpdateBasicInfo(basicinfo);
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
        public async Task<IActionResult> DeleteBasicInfo(int id)
        {
            try
            {
                var dbbasicinfo = await _basicinfoServices.GetBasicInfoById(id);
                if (dbbasicinfo == null)
                {
                    return this.NotFound($"BasicInfo Id {id} not found..");
                }
                int result = await _basicinfoServices.DeleteBasicInfo(id);
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
