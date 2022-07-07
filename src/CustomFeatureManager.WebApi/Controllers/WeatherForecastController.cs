namespace CustomFeatureManager.WebApi.Controllers;

using CustomFeatureManager.Application.Common.Constants;
using CustomFeatureManager.Application.FeatureManagement;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IFeatureManager featureManager;

    private readonly ILogger<WeatherForecastController> logger;

    public WeatherForecastController(IFeatureManager featureManager, ILogger<WeatherForecastController> logger)
    {
        this.featureManager = featureManager;
        this.logger = logger;
    }

    [HttpGet(Name = "Features")]
    public async Task<IActionResult> Features()
    {
        var features = await featureManager.GetFeaturesAsync();
        return Ok(features);
    }

    [HttpGet(Name = "Feature1")]
    public async Task<IActionResult> Feature1()
    {
#if Feature1Permanent
        var isFeatureEnabled = false;
        throw new Exception();
#else
        var isFeatureEnabled = await featureManager.IsEnabledAsync(FeatureCodes.FEATURE1);
#endif

        if (isFeatureEnabled)
        {
            logger.LogInformation("Feature1 enabled");
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
        }

        logger.LogInformation("Feature1 disabled");
        return await Task.FromResult(BadRequest("Feature1 disabled"));
    }

    [HttpGet(Name = "Feature2")]
    public async Task<IActionResult> Feature2()
    {
#if Feature2Permanent
        var isFeatureEnabled = false;
        throw new Exception();
#else
        var isFeatureEnabled = await featureManager.IsEnabledAsync(FeatureCodes.FEATURE2);
#endif

        if (isFeatureEnabled)
        {
            logger.LogInformation("Feature2 enabled");
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
        }

        logger.LogInformation("Feature2 disabled");
        return await Task.FromResult(BadRequest("Feature2 disabled"));
    }

    [HttpGet(Name = "Feature3")]
    public async Task<IActionResult> Feature3()
    {
#if Feature3Permanent
        var isFeatureEnabled = false;
#else
        var isFeatureEnabled = true;
#endif

        if (isFeatureEnabled)
        {
            logger.LogInformation("Feature3 enabled");
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
        }

        logger.LogInformation("Feature3 disabled");
        return await Task.FromResult(BadRequest("Feature3 disabled"));
    }

    [HttpGet(Name = "Feature4")]
    public async Task<IActionResult> Feature4()
    {
#if Feature4Permanent
        var isFeatureEnabled = false;
        throw new Exception();
#else
        var isFeatureEnabled = await featureManager.IsEnabledAsync(FeatureCodes.FEATURE4);
#endif

        if (isFeatureEnabled)
        {
            logger.LogInformation("Feature4 enabled");
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
        }

        logger.LogInformation("Feature4 disabled");
        return await Task.FromResult(BadRequest("Feature4 disabled"));
    }

    [HttpGet(Name = "Feature5")]
    public async Task<IActionResult> Feature5()
    {
#if Feature5Permanent
        var isFeatureEnabled = false;
        throw new Exception();
#else
        var isFeatureEnabled = await featureManager.IsEnabledAsync(FeatureCodes.FEATURE5);
#endif

        if (isFeatureEnabled)
        {
            logger.LogInformation("Feature5 enabled");
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray());
        }

        logger.LogInformation("Feature5 disabled");
        return await Task.FromResult(BadRequest("Feature5 disabled"));
    }
}