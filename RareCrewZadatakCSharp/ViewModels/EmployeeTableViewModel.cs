using RareCrewZadatakCSharp.DTOs;

namespace RareCrewZadatakCSharp.ViewModels
{
    public class EmployeeTableViewModel
    {
        public const double LowHoursThreshold = 100;

        public string? ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public List<EmployeeSummaryDTO> Employees { get; set; } = new();
    }
}
