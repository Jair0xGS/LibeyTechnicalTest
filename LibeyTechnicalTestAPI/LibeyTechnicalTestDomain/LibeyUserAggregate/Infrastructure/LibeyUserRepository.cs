using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<LibeyUserResponse> List(int page, int limit)
        {
            return _context.LibeyUsers
            .Skip((page-1)*limit)
            .Take(limit)
            .ToList()
            .Select(x=>x.ToResponse());
        }

        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public void Update(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Update(libeyUser);
            _context.SaveChanges();
        }

        public void Delete(string documentNumber)
        {
            var elem = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber.Equals(documentNumber));
            if (elem == null) return;
            _context.LibeyUsers.Remove(elem);
            _context.SaveChanges();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers
                    .Where(x => x.DocumentNumber.Equals(documentNumber))
                select libeyUser.ToResponse();
            var list = q.ToList();
            return list.Any() ? list.First() : new LibeyUserResponse();
        }
    }
}