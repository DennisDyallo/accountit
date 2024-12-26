namespace Taxana.Backend.Infrastructure;

public interface ISchemaService
{
    public Task InitializeAsync();
    public Task ResetDatabaseAsync();
}