using WebApi.Configuration;

namespace WebApi.Extensions;

public static class ApplicationOptionsExtensions
{
    public static void AddApplicationOptions(this IServiceCollection services)
    {
        var configSection = services.BuildServiceProvider()
                                    .GetRequiredService<IConfiguration>()
                                    .GetSection(SpaOptions.SectionName);
        var spaOptions = configSection.Get<SpaOptions>();
        spaOptions = spaOptions?.Config switch
        {
            SpaConfiguration.UseProxyToDevServer => configSection.Get<SpaUseProxyToDevServerOptions>(),
            SpaConfiguration.LaunchLocalDevServer => configSection.Get<SpaLaunchLocalDevServer>(),
            SpaConfiguration.StaticFiles => configSection.Get<SpaStaticFiles>(),
            null or _ => null,
        };
        spaOptions ??= new SpaStaticFiles();
        services.AddSingleton<SpaOptions>(spaOptions);
    }
}