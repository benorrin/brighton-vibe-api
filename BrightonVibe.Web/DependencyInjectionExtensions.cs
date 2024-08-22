using Microsoft.Extensions.DependencyInjection;
using BrightonVibe.Application.Services;
using BrightonVibe.Data.Repositories;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Domain.Services;

public static class DependencyInjectionExtensions
{
    public static void AddDependencyInjectionServices(this IServiceCollection services)
    {
        // Application Services
        services.AddScoped<AccountApplicationService>();
        services.AddScoped<VenueApplicationService>();
        services.AddScoped<VenueTypeApplicationService>();
        services.AddScoped<VenueCategoryApplicationService>();

        // Domain Services
        services.AddScoped<IAccountDomainService, AccountDomainService>();

        // Repositories
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IVenueRepository, VenueRepository>();
        services.AddScoped<IVenueTypeRepository, VenueTypeRepository>();
        services.AddScoped<IVenueImageRepository, VenueImageRepository>();
        services.AddScoped<IVenueOpeningHourRepository, VenueOpeningHourRepository>();
        services.AddScoped<IVenueCategoryRepository, VenueCategoryRepository>();
    }
}