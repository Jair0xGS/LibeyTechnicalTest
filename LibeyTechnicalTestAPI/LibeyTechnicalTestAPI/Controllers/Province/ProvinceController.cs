using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Province;

[ApiController]
[Route("[controller]")]
public class ProvinceController : Controller
{
    private readonly IProvinceAggregate _aggregate;

    public ProvinceController(IProvinceAggregate aggregate)
    {
        _aggregate = aggregate;
    }

    [HttpGet]
    [Route("{regionCode}")]
    public IActionResult List(string regionCode)
    {
        var row = _aggregate.List(regionCode);
        return Ok(row);
    }
}