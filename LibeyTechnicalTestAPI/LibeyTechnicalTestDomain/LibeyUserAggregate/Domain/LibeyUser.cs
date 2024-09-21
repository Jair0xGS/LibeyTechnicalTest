using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class LibeyUser
    {
        public string DocumentNumber { get; private set; }
        public int DocumentTypeId { get; private set; }
        public string Name { get; private set; }
        public string FathersLastName { get; private set; }
        public string MothersLastName { get; private set; }
        public string Address { get; private set; }
        public string UbigeoCode { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public LibeyUser(string documentNumber, int documentTypeId, string name, string fathersLastName,
            string mothersLastName, string address,
            string ubigeoCode, string phone, string email, string password)
        {
            DocumentNumber = documentNumber;
            DocumentTypeId = documentTypeId;
            Name = name;
            FathersLastName = fathersLastName;
            MothersLastName = mothersLastName;
            Address = address;
            UbigeoCode = ubigeoCode;
            Phone = phone;
            Email = email;
            Password = password;
            Active = true;
        }

        public LibeyUserResponse ToResponse()
        {
            var region = UbigeoCode.Substring(0, 2);
            var province = UbigeoCode.Substring(0, 4);
            return new LibeyUserResponse()
            {
                DocumentNumber = DocumentNumber,
                Active = Active,
                Address = Address,
                DocumentTypeId = DocumentTypeId,
                Email = Email,
                FathersLastName = FathersLastName,
                MothersLastName = MothersLastName,
                Name = Name,
                Password = Password,
                Phone = Phone,
                UbigeoCode = UbigeoCode,
                RegionCode = region,
                ProvinceCode = province,
            };
        }

        public static LibeyUser FromCommand(UserUpdateorCreateCommand command)
        {
            return new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password
            );
        }
    }
}