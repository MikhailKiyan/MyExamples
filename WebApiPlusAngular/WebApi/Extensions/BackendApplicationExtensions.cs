using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Options;
using WebApi.Configuration;

namespace WebApi.Extensions;

public static class BackendApplicationExtensions
{
    public static void UseBackendApplication(this IApplicationBuilder app)
    {
        var config = app.ApplicationServices.GetRequiredService<IConfiguration>();
        var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
        var spaOptions = app.ApplicationServices.GetRequiredService<SpaOptions>();
        switch ((env.IsProduction(), spaOptions.Config))
        {
            case (false, SpaConfiguration.UseProxyToDevServer): {
                var spaConfig = (SpaUseProxyToDevServerOptions)spaOptions;
                app.UseSpa(spa => { spa.UseProxyToSpaDevelopmentServer(spaConfig.ProxyUrl); });
                break;
            }

            case (false, SpaConfiguration.LaunchLocalDevServer): {
                var spaConfig = (SpaLaunchLocalDevServer)spaOptions;
                app.UseSpa(spa => {
                    spa.Options.SourcePath = spaConfig.Path.ToString();
                    spa.UseAngularCliServer(spaConfig.NpmCommand);
                });
                break;
            }

            default:
            case (_, SpaConfiguration.Default):
            case (_, SpaConfiguration.StaticFiles): {
                app.UseEndpoints(endpoints => endpoints.MapFallbackToFile("index.html"));
                app.UseStaticFiles();
                break;
            }
        }
    }
}
