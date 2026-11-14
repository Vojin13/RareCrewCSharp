using RareCrewZadatakCSharp.DTOs;

namespace RareCrewZadatakCSharp.Services.Interfaces
{
    public interface IEmployeeReportService
    {
        Task<List<EmployeeSummaryDTO>> GetEmployeeSummariesAsync(CancellationToken cancellationToken = default);
    }
}
