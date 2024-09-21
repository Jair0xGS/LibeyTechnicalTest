﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class RegionAggregate:IRegionAggregate
{
    private readonly IRegionRepository _repository;

    public RegionAggregate(IRegionRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<RegionResponse> List()
    {
        return _repository.List();
    }
}