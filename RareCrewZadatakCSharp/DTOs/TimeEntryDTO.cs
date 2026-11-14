using System.Text.Json.Serialization;

namespace RareCrewZadatakCSharp.DTOs
{
    public class TimeEntryDTO
    {
        public Guid Id { get; set; }

        public string? EmployeeName { get; set; }

        [JsonPropertyName("StarTimeUtc")]
        public DateTime StartTimeUtc { get; set; }

        public DateTime EndTimeUtc { get; set; }

        public string? EntryNotes { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
