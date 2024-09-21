using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class ProvinceAggregate:IProvinceAggregate
{
    private readonly IProvinceRepository _repository;

    public ProvinceAggregate(IProvinceRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<ProvinceResponse> List(string regionCode)
    {
        return _repository.List(regionCode);
    }
}