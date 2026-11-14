using RareCrewZadatakCSharp.Services;
using RareCrewZadatakCSharp.Services.Interfaces;

namespace RareCrewZadatakCSharp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new AppSettings();
            configuration.Bind(settings);
            services.AddSingleton(settings);

            return settings;
        }

        public static IServiceCollection AddReportServices(this IServiceCollection services, AppSettings settings)
        {
            services.AddHttpClient<ITimeEntryService, TimeEntryService>(client =>
                client.BaseAddress = new Uri(settings.TimeEntries.BaseUrl));

            services.AddTransient<IEmployeeSummaryService, EmployeeSummaryService>();
            services.AddTransient<IEmployeeReportService, EmployeeReportService>();
            services.AddTransient<IChartGenerator, ScottPlotChartGenerator>();

            return services;
        }
    }
}
