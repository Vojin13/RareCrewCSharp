using RareCrewZadatakCSharp.DTOs;
using RareCrewZadatakCSharp.Services.Interfaces;

namespace RareCrewZadatakCSharp.Services
{
    public class EmployeeSummaryService : IEmployeeSummaryService
    {
        public List<EmployeeSummaryDTO> SummarizeEmployees(IEnumerable<TimeEntryDTO> timeEntries)
        {
            return timeEntries
                .Where(IsEntryValid)
                .GroupBy(x => x.EmployeeName)
                .Select(x => new EmployeeSummaryDTO
                {
                    Name = x.Key,
                    TotalTime = TimeSpan.FromTicks(x.Sum(GetDurationTicks))
                })
                .OrderByDescending(summary => summary.TotalTime)
                .ToList();
        }

        private static bool IsEntryValid(TimeEntryDTO entry)
        {
            return entry.DeletedOn == null
                && entry.StartTimeUtc < entry.EndTimeUtc
                && !string.IsNullOrWhiteSpace(entry.EmployeeName);
        }

        private static long GetDurationTicks(TimeEntryDTO entry)
        {
            return (entry.EndTimeUtc - entry.StartTimeUtc).Ticks;
        }
    }
}
