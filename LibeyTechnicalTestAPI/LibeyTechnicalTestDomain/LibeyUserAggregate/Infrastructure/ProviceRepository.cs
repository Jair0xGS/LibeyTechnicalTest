using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class ProviceRepository : IProvinceRepository
{
    private readonly Context _context;

    public ProviceRepository(Context context)
    {
        _context = context;
    }

    public IEnumerable<ProvinceResponse> List(string regionCode)
    {
        return _context.Provinces
            .Where(province => province.RegionCode == regionCode)
            .ToList()
            .Select(province => new ProvinceResponse()
            {
                RegionCode = province.RegionCode,
                ProvinceCode = province.ProvinceCode,
                ProvinceDescription = province.ProviceDescription,
            });
    }
}