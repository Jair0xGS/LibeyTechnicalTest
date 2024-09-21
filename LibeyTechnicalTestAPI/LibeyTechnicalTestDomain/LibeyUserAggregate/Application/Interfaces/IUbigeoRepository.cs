using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IUbigeoRepository
{
        IEnumerable<UbigeoResponse> List(string provinceCode,string regionCode);
}