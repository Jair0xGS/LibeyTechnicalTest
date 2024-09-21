using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        IEnumerable<LibeyUserResponse> List(int page, int limit);
        void Create(LibeyUser libeyUser);
        void Update(LibeyUser libeyUser);
        void Delete(string documentNumber);
    }
}
