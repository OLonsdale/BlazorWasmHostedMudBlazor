using System.Net.Http.Json;
using System.Text.Json;
using Base.Client.Services;
using Base.Shared.Statics;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Base.Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");


        builder.Services.AddMudServices();
        builder.Services.AddScoped<DataService>();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddScoped<AppState>();
        
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}") });


        await builder.Build().RunAsync();
    }

}