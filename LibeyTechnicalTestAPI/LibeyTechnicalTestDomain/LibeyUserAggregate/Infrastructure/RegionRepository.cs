using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class RegionRepository:IRegionRepository
{
    
        private readonly Context _context;
        public  RegionRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<RegionResponse> List()
        {
            return from region in _context.Regions.ToList()
                select new RegionResponse()
                {
                    RegionCode = region.RegionCode,
                    RegionDescription = region.RegionDescription,
                };
        }
}