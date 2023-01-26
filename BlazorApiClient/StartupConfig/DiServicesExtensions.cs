namespace BlazorApiClient.StartupConfig;

public static class DIServicesExtensions
{
    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }

    public static void AddHttpClientServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("api", opts => opts.AddHttpClientOptions(builder));
    }

}
