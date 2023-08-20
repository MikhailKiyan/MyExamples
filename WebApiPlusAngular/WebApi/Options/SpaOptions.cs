namespace WebApi.Options;

internal enum SpaConfig { StaticFiles, SpaStaticFiles, UseProxy, UseDevServer }

internal class BaseSpaOptions {

    public static string SectionName = "SPA";

    public SpaConfig Config { get; set; }
}

internal sealed class StaticFiles : BaseSpaOptions { }

internal sealed class SpaStaticFiles : BaseSpaOptions
{
    public Uri Path { get; set; }
}


internal sealed class SpaUseProxyOptions : BaseSpaOptions
{
    public Uri Url { get; set; }
}

internal sealed class SpaUseDevServer : BaseSpaOptions
{
    public Uri Path { get; set; }

    public string Command { get; set; }
}
