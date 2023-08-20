using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace WebApi.Extensions;

public static class BackendApplicationExtensions
{
    public static void UseBackendApplication(this IApplicationBuilder app)
    {
        var config = app.ApplicationServices.GetRequiredService<IConfiguration>();
        var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();
        var spaConfig = config.GetSection("SPA")?.GetValue<string>("start")?.ToLowerInvariant();

        
        /*
        if (env.IsDevelopment()) {
            app.UseSpa(spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                
                
                // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                
                spa.Options.SourcePath = "../UI";
                spa.UseAngularCliServer("start");

            });
        }
        */
    }

}