namespace BlazorApiClient.StartupConfig;

public static class DIServicesOptionsExtensions
{
    public static void AddHttpClientOptions(this HttpClient opts, WebApplicationBuilder builder)
    {
        opts.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
    }
}
