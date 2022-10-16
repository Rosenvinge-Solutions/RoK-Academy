using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace WebApp.Shared.Extensions;

public static class WebAssemblyHostExtensions
{
    public static async Task SetDefaultHostCulture(this WebAssemblyHost host)
    {
        IJSObjectReference cultureJsModule = await GetJsModuleAsync(host, "./js/culture.js");

        string? result = await cultureJsModule.InvokeAsync<string>("getCulture");

        CultureInfo culture;

        if (result is not null && !string.IsNullOrEmpty(result))
        {
            culture = new CultureInfo(result);
        }
        else
        {
            culture = new CultureInfo("en-US");

            await cultureJsModule.InvokeVoidAsync("setCulture", culture.Name);
        }

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }

    public static async Task SetDefaultHostQueryMode(this WebAssemblyHost host)
    {
        IJSObjectReference settingsJsModule = await GetJsModuleAsync(host, "./js/settings.js");

        string? result = await settingsJsModule.InvokeAsync<string>("getSearchQueryMode");

        if (result is not null && !string.IsNullOrEmpty(result))
        {
            return;
        }

        await settingsJsModule.InvokeVoidAsync("setSearchQueryMode", 0);
    }

    private static async Task<IJSObjectReference> GetJsModuleAsync(WebAssemblyHost host, string modulePath)
        => await host
            .Services
            .GetRequiredService<IJSRuntime>()
            .InjectJsObjectReference("import", modulePath);
}