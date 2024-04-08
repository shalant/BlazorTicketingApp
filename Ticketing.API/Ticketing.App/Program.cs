using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ticketing.App;
using Ticketing.App.Services;
using Ticketing.App.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IDriverService, DriverService>();

builder.Services.AddScoped(hc => new HttpClient()
{
    BaseAddress = new Uri("http://localhost:7224/")
});

await builder.Build().RunAsync();
