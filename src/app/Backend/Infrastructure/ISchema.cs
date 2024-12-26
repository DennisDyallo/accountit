namespace Taxana.Backend.Infrastructure;

public interface ISchema
{
    IReadOnlyDictionary<string, string> GetSchema();
}