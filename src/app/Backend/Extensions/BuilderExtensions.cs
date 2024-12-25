using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Taxana.Backend.Infrastructure;
public static class BuilderExtensions
{
    public static WebAssemblyHostBuilder AddTaxanaDependencies(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddSingleton<IDexieStore, DexieStore>();
        builder.Services.AddSingleton<ISchemaService, TaxanaSchemaService>();

        return builder;
    }
}