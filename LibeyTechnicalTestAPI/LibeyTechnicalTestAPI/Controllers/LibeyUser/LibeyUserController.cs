using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }
        
        [HttpGet]
        [Route("list")]
        public IActionResult List( int page,int limit )
        {
            var elems = _aggregate.List(page,limit);
            return Ok(elems);
        }
        
        
        [HttpPost]       
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
             _aggregate.Create(command);
            return Ok(true);
        }
        
        [HttpPut]       
        public IActionResult Update(UserUpdateorCreateCommand command)
        {
             _aggregate.Update(command);
            return Ok(true);
        }
        
        [HttpDelete("{documentNumber}")]       
        public IActionResult Update(string documentNumber)
        {
             _aggregate.Delete(documentNumber);
            return Ok(true);
        }
    }
}