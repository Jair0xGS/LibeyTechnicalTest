using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo;

[ApiController]
[Route("[controller]")]
public class UbigeoController:Controller
{
    private readonly IUbigeoAggregate _aggregate;

    public UbigeoController(IUbigeoAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    

    [HttpGet]
    [Route("{regionCode}/{provinceCode}")]
    public IActionResult List(string regionCode,string provinceCode)
    {
        var row = _aggregate.List(provinceCode,regionCode);
        return Ok(row);
    }
}