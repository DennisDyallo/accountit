using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Taxana.Backend.Infrastructure;

namespace Taxana.Backend;
public static class BuilderExtensions
{
    public static WebAssemblyHostBuilder AddTaxanaDependencies(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddSingleton<IDexieStore, DexieStore>();
        builder.Services.AddSingleton<ISchemaService, SchemaService>();
        builder.Services.AddSingleton<ISchema, Schema>();

        return builder;
    }
}