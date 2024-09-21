using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IProvinceAggregate
{
    
        IEnumerable<ProvinceResponse> List(string regionCode);
}