using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LibeyUserResponse> List(int page, int limit)
        {
            if (page < 0) page = 0;
            if (limit > 20) limit = 20;
            if (limit < 5) limit = 5;
            return _repository.List(page, limit);
        }

        public void Create(UserUpdateorCreateCommand command)
        {
            //TODO add password encryption
            _repository.Create(LibeyUser.FromCommand(command));
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            _repository.Update(LibeyUser.FromCommand(command));
        }

        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
    }
}