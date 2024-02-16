using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestSharp;
using WasmApp;
using WasmApp.Interfaces;
using WasmApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5095/")
});

builder.Services.AddTransient<IRestClient, RestClient>();

builder.Services.AddScoped<ICategoryService, CategoryService>();


await builder.Build().RunAsync();