using RareCrewZadatakCSharp.DTOs;

namespace RareCrewZadatakCSharp.Services.Interfaces
{
    public interface IChartGenerator
    {
        byte[] GeneratePieChartPng(List<EmployeeSummaryDTO> employees);
    }
}
