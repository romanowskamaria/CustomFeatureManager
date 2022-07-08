namespace CustomFeatureManager.Infrastructure.FeatureManagement;

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
internal static class DependencyInjection
{
    public static void AddFeatureManagement(this IServiceCollection services, IConfiguration configuration)
    {
        Microsoft.FeatureManagement.ServiceCollectionExtensions.AddFeatureManagement(services, configuration.GetSection(FeatureManagementOptions.SECTION_NAME));
    }
}
