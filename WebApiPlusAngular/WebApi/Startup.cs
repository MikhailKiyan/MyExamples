using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using WebApi.Extensions;

namespace WebApiPlusAngular.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration) => this.Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        /*services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "SpaStaticFiles";
        });*/
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        } else {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        //app.UseStaticFiles();
        //app.UseSpaStaticFiles();
        /*app.UseSpa(spa => {
            spa.Options.SourcePath = ".";
        });*/

        app.UseRouting();
        app.UseEndpoints(endpoints =>{
            // endpoints.MapFallbackToFile("index.html");
            endpoints.MapControllers();
        });

        //app.UseBackendApplication();

        if (env.IsDevelopment()) {
            app.UseSpa(spa => {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                
                
                // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                
                spa.Options.SourcePath = "../UI";
                spa.UseAngularCliServer("start");

            });
        }
    }
}
