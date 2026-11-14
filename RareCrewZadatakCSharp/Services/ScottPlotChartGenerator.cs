using RareCrewZadatakCSharp.DTOs;
using RareCrewZadatakCSharp.Services.Interfaces;
using ScottPlot;

namespace RareCrewZadatakCSharp.Services
{
    public class ScottPlotChartGenerator : IChartGenerator
    {
        private const int Width = 900;
        private const int Height = 600;

        public byte[] GeneratePieChartPng(List<EmployeeSummaryDTO> employees)
        {
            Plot plot = new();

            double[] hours = employees
                .Select(employee => employee.TotalTime.TotalHours)
                .ToArray();

            var pie = plot.Add.Pie(hours);
            pie.SliceLabelDistance = 0.6;

            double totalHours = hours.Sum();

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                double percentage = hours[i] / totalHours * 100;

                pie.Slices[i].Label = $"{percentage:0.0}%";
                pie.Slices[i].LabelFontSize = 16;
                pie.Slices[i].LabelBold = true;
                pie.Slices[i].LegendText = employees[i].Name;
            }

            plot.Axes.Frameless();
            plot.HideGrid();
            plot.ShowLegend();

            return plot.GetImageBytes(Width, Height, ImageFormat.Png);
        }
    }
}
