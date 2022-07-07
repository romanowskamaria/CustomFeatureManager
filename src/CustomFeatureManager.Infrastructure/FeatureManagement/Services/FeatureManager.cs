namespace CustomFeatureManager.Infrastructure.FeatureManagement.Services;

using CustomFeatureManager.Application.FeatureManagement;
using Microsoft.Extensions.Options;

internal class FeatureManager : IFeatureManager
{
    private readonly FeatureManagementOptions featureManagementOptions;

    public FeatureManager(IOptions<FeatureManagementOptions> featureManagementOptions)
    {
        this.featureManagementOptions = featureManagementOptions.Value;
    }

    public async Task<bool> IsEnabledAsync(string feature)
    {
        if (featureManagementOptions.TryGetValue(feature, out var enabled))
        {
            return await Task.FromResult(enabled);
        }

        return await Task.FromResult(true);
    }

    public async Task<Dictionary<string, bool>> GetFeaturesAsync()
    {
        return await Task.FromResult(featureManagementOptions);
    }
}