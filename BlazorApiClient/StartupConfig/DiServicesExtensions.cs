using BlazorApiClient.Models;

namespace BlazorApiClient.StartupConfig;

public static class DIServicesExtensions
{
    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }

    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<TokenModel>();
    }

    public static void AddHttpClientServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("api", opts => opts.AddHttpClientOptions(builder));
    }

}
