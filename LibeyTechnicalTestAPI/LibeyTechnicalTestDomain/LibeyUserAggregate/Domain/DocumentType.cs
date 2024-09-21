namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

public class DocumentType
{
        public DocumentType(int documentTypeId, string documentTypeDescription)
        {
                DocumentTypeId = documentTypeId;
                DocumentTypeDescription = documentTypeDescription;
        }

        public int DocumentTypeId { get; private set; }
        public string DocumentTypeDescription  { get; private set; }
}