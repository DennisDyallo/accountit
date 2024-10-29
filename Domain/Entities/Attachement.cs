// Bilaga/underlag
namespace Domain.Entities;

public class Attachment
{
    public string Id { get; init; }
    
    // Filnamn
    public string FileName { get; init; }
    
    // Filtyp
    public string ContentType { get; init; }
    
    // Fildata
    public byte[] Data { get; init; }
}