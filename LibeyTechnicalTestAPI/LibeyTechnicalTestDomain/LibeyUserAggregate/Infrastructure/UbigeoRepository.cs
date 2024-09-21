using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class UbigeoRepository:IUbigeoRepository
{
    private readonly Context _context;

    public UbigeoRepository(Context context)
    {
        _context = context;
    }

    public IEnumerable<UbigeoResponse> List(string provinceCode, string regionCode)
    {
        return _context.Ubigeos
            .Where(ubigeo => 
                ubigeo.RegionCode == regionCode && 
                ubigeo.ProvinceCode==provinceCode)
            .ToList()
            .Select(ubigeo => new UbigeoResponse()
            {
                RegionCode = ubigeo.RegionCode,
                ProvinceCode = ubigeo.ProvinceCode,
                UbigeoCode = ubigeo.UbigeoCode,
                UbigeoDescription = ubigeo.UbigeoDescription,
            });
    }
}