using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IUbigeoAggregate
{
        IEnumerable<UbigeoResponse> List(string provinceCode,string regionCode);
}