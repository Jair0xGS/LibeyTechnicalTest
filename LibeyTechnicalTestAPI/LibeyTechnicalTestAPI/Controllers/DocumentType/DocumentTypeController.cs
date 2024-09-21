using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumentType;

[ApiController]
[Route("[controller]")]
public class DocumentTypeController:Controller
{
    private readonly IDocumentTypeAggregate _documentTypeAggregate;

    public DocumentTypeController(IDocumentTypeAggregate documentTypeAggregate)
    {
        _documentTypeAggregate = documentTypeAggregate;
    }

    [HttpGet]
    public IActionResult FindResponse()
    {
        var row = _documentTypeAggregate.List();
        return Ok(row);
    }
}