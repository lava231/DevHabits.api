using System.Reflection.Metadata.Ecma335;

namespace DevHabits.api.Entities;

public sealed class Tag
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
}
