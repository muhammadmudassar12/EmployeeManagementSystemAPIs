using EmployManagementSystemAPIs.Model;
using EmployManagementSystemAPIs.Services.EmgContactInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployManagementSystemAPIs.Controllers
{
    [Route("EmgContactInfo/api/")]
    public class EmgContactInfoController : Controller
    {
            private readonly IEmgContactInfoServices _emgcontactinfoServices;
            public EmgContactInfoController(IEmgContactInfoServices emgcontactinfoServices)
            {
            _emgcontactinfoServices = emgcontactinfoServices;
            }
            [HttpGet()]
            public async Task<IActionResult> GetAllEmgContactInfo()
            {
                var emgcontactinfo = await _emgcontactinfoServices.GetAllEmgContactInfo();
                if (emgcontactinfo.Count == 0)
                {
                    return NotFound("EmgContactInfo not exist");
                }


                return this.Ok(emgcontactinfo);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetEmgContactInfoById(int id)
            {
                var emgcontactinfo = await _emgcontactinfoServices.GetEmgContactInfoById(id);
                if (emgcontactinfo == null)
                {
                    return NotFound($"EmgContactInfo Id {id} not exist");
                }


                return this.Ok(emgcontactinfo);
            }
            [HttpPost()]
            public async Task<IActionResult> PostEmgContactInfo([FromBody] EmgContactInfo emgcontactinfo)
            {
                try
                {
                    int result = await _emgcontactinfoServices.PostEmgContactInfo(emgcontactinfo);
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
            public async Task<IActionResult> UpdateEmgContactInfo(int id, [FromBody] EmgContactInfo emgcontactinfo)
            {
                try
                {
                    var dbemgcontactinfo = await _emgcontactinfoServices.GetEmgContactInfoById(id);
                    if (dbemgcontactinfo == null)
                    {
                        return this.NotFound($"EmgContactInfo Id {id} not found..");
                    }

                emgcontactinfo.Id = id;
                    int result = await _emgcontactinfoServices.UpdateEmgContactInfo(emgcontactinfo);
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
            public async Task<IActionResult> DeleteEmgContactInfo(int id)
            {
                try
                {
                    var dbemgcontactinfo = await _emgcontactinfoServices.GetEmgContactInfoById(id);
                    if (dbemgcontactinfo == null)
                    {
                        return this.NotFound($"EmgContactInfo Id {id} not found..");
                    }
                    int result = await _emgcontactinfoServices.DeleteEmgContactInfo(id);
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
