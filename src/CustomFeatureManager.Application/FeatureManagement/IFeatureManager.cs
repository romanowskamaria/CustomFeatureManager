namespace CustomFeatureManager.Application.FeatureManagement;

public interface IFeatureManager
{
    /// <summary>Checks whether a given feature is enabled.</summary>
    /// <param name="feature">The name of the feature to check.</param>
    /// <returns>False if the feature is disabled, otherwise true.</returns>
    Task<bool> IsEnabledAsync(string feature);

    Task<Dictionary<string, bool>> GetFeaturesAsync();
}
