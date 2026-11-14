using RareCrewZadatakCSharp.DTOs;

namespace RareCrewZadatakCSharp.Services.Interfaces
{
    public interface IEmployeeSummaryService
    {
        List<EmployeeSummaryDTO> SummarizeEmployees(IEnumerable<TimeEntryDTO> timeEntries);
    }
}
