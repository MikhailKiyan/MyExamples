namespace WebApiPlusAngular.WebApi;

public class Program
{
    public static async Task Main(string[] args) {
        var host = CreateHostBuilder(args).Build();
        await host.StartAsync();
        var logger = host.Services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("It started with Process Id: {processId}", Environment.ProcessId);
        logger.LogInformation("It started on machine '{machineName}', user '{user}', and user domen '{userDomen}'",
            Environment.MachineName, Environment.UserName, Environment.UserDomainName);
        try {
            await host.WaitForShutdownAsync();
        } catch (Exception ex) {
            logger.LogCritical(ex, "Aplication was terminated");
        }
        logger.LogInformation("Application has finished with exit code '{exitCode}'", Environment.ExitCode);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
