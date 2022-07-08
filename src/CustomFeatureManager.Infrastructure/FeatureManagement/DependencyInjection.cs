namespace CustomFeatureManager.Infrastructure.FeatureManagement;

using System.Diagnostics.CodeAnalysis;
using CustomFeatureManager.Application.FeatureManagement;
using CustomFeatureManager.Infrastructure.FeatureManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static void AddFeatureManagement(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FeatureManagementOptions>(configuration.GetSection(FeatureManagementOptions.SECTION_NAME));
        services.AddScoped<IFeatureManager, FeatureManager>();
    }
}
