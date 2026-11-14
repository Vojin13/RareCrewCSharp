using RareCrewZadatakCSharp.DTOs;
using RareCrewZadatakCSharp.Services.Interfaces;

namespace RareCrewZadatakCSharp.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public TimeEntryService(HttpClient httpClient, AppSettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<List<TimeEntryDTO>> GetTimeEntriesAsync(CancellationToken cancellationToken = default)
        {
            var entries = await _httpClient.GetFromJsonAsync<List<TimeEntryDTO>>(
                $"api/gettimeentries?code={_settings.TimeEntries.Code}",
                cancellationToken);

            return entries ?? new List<TimeEntryDTO>();
        }
    }
}
