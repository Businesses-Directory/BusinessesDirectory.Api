using System.Threading.Tasks;
using BusinessesDirectoryApi.Dtos.CreateDtos.BusinessDtos;
using BusinessesDirectoryApi.Dtos.ParamsDtos;
using BusinessesDirectoryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessesDirectoryApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    public readonly IBusinessService _businessService;
    public BusinessesController(IBusinessService businessService)
    {
      this._businessService = businessService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBusinesses([FromQuery] BusinessSearchParams businessSearchParams)
    {
      var businesses = await _businessService.FindBusinesses(businessSearchParams);
      return Ok(businesses);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBusiness([FromBody] BusinessToCreateDto businessToCreateDto)
    {
      var business = businessToCreateDto;
      return Ok(business);
      // var business = await _businessService.AddABusiness(businessToCreateDto);
      // return CreatedAtRoute(null, business);
    }
    // GET api/values/5
    // [HttpGet("{id}")]
    // public ActionResult<string> Get(int id)
    // {
    //     return "value";
    // }
    // PUT api/values/5
    // [HttpPut("{id}")]
    // public void Put(int id, [FromBody] string value)
    // {
    // }
    // DELETE api/values/5
    // [HttpDelete("{id}")]
    // public void Delete(int id)
    // {
    // }
  }
}
