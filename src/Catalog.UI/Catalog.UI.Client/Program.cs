using Catalog.UI.Shared.Infra.Extensions;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddFrontEndSetup(builder.Configuration);

await builder.Build().RunAsync();