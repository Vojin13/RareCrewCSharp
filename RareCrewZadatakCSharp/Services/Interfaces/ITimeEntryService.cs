using RareCrewZadatakCSharp.DTOs;

namespace RareCrewZadatakCSharp.Services.Interfaces
{
    public interface ITimeEntryService
    {
        Task<List<TimeEntryDTO>> GetTimeEntriesAsync(CancellationToken cancellationToken = default);
    }
}
