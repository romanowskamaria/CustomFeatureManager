namespace CustomFeatureManager.Infrastructure.FeatureManagement;

using System.Diagnostics.CodeAnalysis;

// ReSharper disable once ClassNeverInstantiated.Global
[ExcludeFromCodeCoverage]
internal sealed class FeatureManagementOptions : Dictionary<string, bool>
{
    public static readonly string SECTION_NAME = "FeatureManagement";

    public FeatureManagementOptions() : base(StringComparer.InvariantCultureIgnoreCase)
    {
    }
}
