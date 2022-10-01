using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WebApp.Shared.Extensions
{
    public static class WebAssemblyHostExtensions
    {
        public static async Task SetDefaultHostCulture(this WebAssemblyHost host)
        {
            IJSRuntime js = host.Services.GetRequiredService<IJSRuntime>();
            IJSObjectReference cultureJsModule = await js.InjectJsObjectReference("import", "./js/culture.js");

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
            IJSRuntime js = host.Services.GetRequiredService<IJSRuntime>();
            IJSObjectReference settingsJsModule = await js.InjectJsObjectReference("import", "./js/settings.js");

            string? result = await settingsJsModule.InvokeAsync<string>("getSearchQueryMode");

            if (result is not null && !string.IsNullOrEmpty(result))
            {
                return;
            }

            await settingsJsModule.InvokeVoidAsync("setSearchQueryMode", 0);
        }
    }
}
