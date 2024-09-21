using LibeyTechnicalTestDomain.LibeyUserAggregate.Application;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;
namespace LibeyTechnicalTestAPI.Middleware
{
    public static class DIExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services)
        {
            //aggregates
            services.AddTransient<ILibeyUserAggregate, LibeyUserAggregate>();
            services.AddTransient<IDocumentTypeAggregate, DocumentTypeAggregate>();
            //repos
            services.AddTransient<ILibeyUserRepository, LibeyUserRepository>();
            services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddTransient<IRegionRepository,RegionRepository>();
            services.AddTransient<IProvinceRepository,ProviceRepository>();
            services.AddTransient<IUbigeoRepository,UbigeoRepository>();
            return services;
        }
    }
}
