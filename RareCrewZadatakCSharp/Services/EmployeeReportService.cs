using RareCrewZadatakCSharp.DTOs;
using RareCrewZadatakCSharp.Services.Interfaces;

namespace RareCrewZadatakCSharp.Services
{
    public class EmployeeReportService : IEmployeeReportService
    {
        private readonly ITimeEntryService _timeEntryService;
        private readonly IEmployeeSummaryService _employeeSummaryService;

        public EmployeeReportService(
            ITimeEntryService timeEntryService,
            IEmployeeSummaryService employeeSummaryService)
        {
            _timeEntryService = timeEntryService;
            _employeeSummaryService = employeeSummaryService;
        }

        public async Task<List<EmployeeSummaryDTO>> GetEmployeeSummariesAsync(CancellationToken cancellationToken = default)
        {
            var entries = await _timeEntryService.GetTimeEntriesAsync(cancellationToken);

            return _employeeSummaryService.SummarizeEmployees(entries);
        }
    }
}
