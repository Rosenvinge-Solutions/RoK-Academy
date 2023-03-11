using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp;
using WebApp.Shared;
using WebApp.Shared.Extensions;
using WebApp.Shared.Modals;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.RootComponents.Add<FeedbackSubmissionModal>("#feedback-container");

builder.Services
    .AddLogging()
    .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
    .AddLocalization(options => options.ResourcesPath = "Resources/LanguageSupport");

WebAssemblyHost host = builder.Build();
await host.SetDefaultHostCulture();
await host.SetDefaultHostQueryMode();

await host.RunAsync();