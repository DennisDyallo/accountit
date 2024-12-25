// Bilaga/underlag
namespace Taxana.Backend.Models;

public class Attachment
{
    public required string Id { get; init; }

    // Filnamn
    public string? FileName { get; init; }

    // Filtyp
    public string? ContentType { get; init; }
}