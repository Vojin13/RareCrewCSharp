using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RareCrewZadatakCSharp.Models;
using RareCrewZadatakCSharp.Services.Interfaces;
using RareCrewZadatakCSharp.ViewModels;

namespace RareCrewZadatakCSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeReportService _reportService;
        private readonly IChartGenerator _chartGenerator;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IEmployeeReportService reportService,
            IChartGenerator chartGenerator,
            ILogger<HomeController> logger)
        {
            _reportService = reportService;
            _chartGenerator = chartGenerator;
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _reportService.GetEmployeeSummariesAsync(cancellationToken);

                return View(new EmployeeTableViewModel { Employees = employees });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load employee time entries.");

                return View(new EmployeeTableViewModel
                {
                    ErrorMessage = "Employee data is currently unavailable. Please try again later."
                });
            }
        }

        public async Task<IActionResult> Chart(bool download = false, CancellationToken cancellationToken = default)
        {
            try
            {
                var employees = await _reportService.GetEmployeeSummariesAsync(cancellationToken);

                if (employees.Count == 0)
                {
                    return NoContent();
                }

                var png = _chartGenerator.GeneratePieChartPng(employees);

                return download
                    ? File(png, "image/png", "EmployeeChart.png")
                    : File(png, "image/png");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to generate the employee chart.");

                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
