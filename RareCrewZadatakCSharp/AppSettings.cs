namespace RareCrewZadatakCSharp
{
    public class AppSettings
    {
        public TimeEntriesSettings TimeEntries { get; set; } = new();
    }

    public class TimeEntriesSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
