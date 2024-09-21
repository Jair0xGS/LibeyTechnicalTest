using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IRegionAggregate
{
        IEnumerable<RegionResponse> List();
}