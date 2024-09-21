using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class DocumentTypeAggregate:IDocumentTypeAggregate
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public DocumentTypeAggregate(IDocumentTypeRepository documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }
    public IEnumerable<DocumentTypeResponse> List()
    {
        return _documentTypeRepository.List();
    }
}