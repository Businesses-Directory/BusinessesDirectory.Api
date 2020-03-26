using System;
using System.Threading.Tasks;
using BusinessesDirectoryApi.Services.TypesServices;
using BusinessesDirectoryApi.Validations;
using Microsoft.AspNetCore.Mvc;

namespace BusinessesDirectoryApi.Controllers
{
  public class BusinessTypesController : ControllerBase
  {
    private readonly IBusinessTypeService _businessTypeService;
    public BusinessTypesController(IBusinessTypeService businessTypeService)
    {
      this._businessTypeService = businessTypeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetBusinessTypes()
    {
      var businessTypes = await _businessTypeService.FindBusinessTypes();
      return Ok(businessTypes);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBusinessType([GuidValidationAttribute] string id)
    {
      var businessType = await _businessTypeService.FindBusinessType(Guid.Parse(id));
      return Ok(businessType);
    }
  }
}