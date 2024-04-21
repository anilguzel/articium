using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

public static class SerilogConfigExtension
{
    public static Logger CreateLogger(IConfiguration configuration, string applicationName)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var elasticSinkConfiguration = new ElasticsearchSinkOptions(new Uri(configuration["Elasticsearch:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = $"{applicationName.ToLower().Replace(".", "-")}-{environmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
        };

        return new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails() // Added exception details enrichment
            .Enrich.WithMachineName()
            .MinimumLevel.Debug() // Set minimum level for console logs (optional)
            .WriteTo.Console()
            .WriteTo.Elasticsearch(elasticSinkConfiguration)
            .Enrich.WithProperty("Environment", environmentName)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }
}