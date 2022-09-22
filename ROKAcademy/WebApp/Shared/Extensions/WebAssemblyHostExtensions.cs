using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

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
    }
}
