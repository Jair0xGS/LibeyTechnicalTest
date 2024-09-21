using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class UbigeoAggregate:IUbigeoAggregate
{
    private readonly IUbigeoRepository _repository;

    public UbigeoAggregate(IUbigeoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<UbigeoResponse> List(string provinceCode, string regionCode)
    {
        return _repository.List(provinceCode, regionCode);
    }
}