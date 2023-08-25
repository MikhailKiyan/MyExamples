namespace WebApi.Configuration;

internal enum SpaConfiguration { Default, StaticFiles, UseProxyToDevServer, LaunchLocalDevServer }

internal class SpaOptions {

    public const string SectionName = "SPA";

    public SpaConfiguration Config { get; init; }

    public SpaOptions()
    {
        Config = SpaConfiguration.Default;
    }

    public SpaOptions(SpaConfiguration configuration)
    {
        Config = configuration;
    }
}

internal sealed class SpaStaticFiles : SpaOptions
{
    public SpaStaticFiles() : base(SpaConfiguration.StaticFiles) { }

}

internal sealed class SpaUseProxyToDevServerOptions : SpaOptions
{
    public SpaUseProxyToDevServerOptions() : base(SpaConfiguration.UseProxyToDevServer) { }

    private Uri? proxyUrl;

    public Uri ProxyUrl {
        get => proxyUrl ?? throw new InvalidOperationException($"Value '{nameof(ProxyUrl)}' can't be null");
        init => proxyUrl = value ?? throw new InvalidOperationException($"Value '{nameof(ProxyUrl)}' can't be null");
    }
}

internal sealed class SpaLaunchLocalDevServer : SpaOptions
{
    public SpaLaunchLocalDevServer() : base(SpaConfiguration.LaunchLocalDevServer) { }

    private Uri? path;

    public Uri Path {
        get => path ?? throw new InvalidOperationException($"Value '{nameof(Path)}' can't be null");
        init => path = value ?? throw new InvalidOperationException($"Value '{nameof(Path)}' can't be null");
    }

    private string? npmCommand;

    public string NpmCommand {
        get => npmCommand ?? throw new InvalidOperationException($"Value '{nameof(NpmCommand)}' can't be null");
        init => npmCommand = value ?? throw new InvalidOperationException($"Value '{nameof(NpmCommand)}' can't be null");
    }
}
