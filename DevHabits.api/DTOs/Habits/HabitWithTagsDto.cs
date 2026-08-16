using System.Text.Json.Serialization;
using DevHabits.api.Entities;
using Newtonsoft.Json;

namespace DevHabits.api.DTOs.Habits;

public record HabitWithTagsDto : HabitDto
{
    [JsonProperty(Order = int.MaxValue)]
    public required List<string> Tags { get; init; }
}
