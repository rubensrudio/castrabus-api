using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;

namespace CastraBus.Common.Extensions
{
    public static class SerilogExtension
    {
        public static void AddSerilogApi(IConfiguration configuration)
        {
            string shortDate = DateTime.Now.ToString(Constants.Constants.DateTime.DATE_YYYY_MM_DD_HH_MM_SS_MINUS_LOGS);
            string path = configuration.GetSection("LoggerBasePath").Value;
            string fileName = $@"{path}\{shortDate}.log";
            string template = configuration.GetSection("LoggerFileTemplate").Value;

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
               .Enrich.FromLogContext()
               .Enrich.WithExceptionDetails()
               .Enrich.WithCorrelationId()
                //.Enrich.WithProperty("ApplicationName", $"API CastraBus - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
               .Enrich.WithProperty("ApplicationName", $"API CastraBus")
               .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
               .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
               .WriteTo.Async(wt => wt.Console(outputTemplate: template))
               .WriteTo.File(fileName, outputTemplate: template)
               .CreateLogger();
        }
    }
}
