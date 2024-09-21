using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class DocumentTypeRepository:IDocumentTypeRepository
{
        private readonly Context _context;
        public  DocumentTypeRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<DocumentTypeResponse> List()
        {
            return from docType in _context.DocumentTypes.ToList()
                select new DocumentTypeResponse()
                {
                    DocumentTypeId = docType.DocumentTypeId,
                    DocumentTypeDescription = docType.DocumentTypeDescription,
                };
        }
}