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
            try
            {
                _aggregate.Create(command);
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(false);
            }
        }
        
        [HttpPut]       
        public IActionResult Update(UserUpdateorCreateCommand command)
        {
            try
            {
                _aggregate.Update(command);
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(false);
            }
        }
        
        [HttpDelete("{documentNumber}")]       
        public IActionResult Delete(string documentNumber)
        {
            try
            {
                _aggregate.Delete(documentNumber);
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok(false);
            }
        }
    }
}