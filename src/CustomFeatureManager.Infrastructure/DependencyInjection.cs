namespace CustomFeatureManager.Infrastructure;

using System.Diagnostics.CodeAnalysis;
using CustomFeatureManager.Infrastructure.FeatureManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFeatureManagement(configuration);
    }
}