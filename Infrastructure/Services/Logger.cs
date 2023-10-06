using Application.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Logger : Application.Services.ILogger
    {
        private readonly Serilog.ILogger _logger; // Initialize this with your chosen logging framework

        public Logger()
        {
            // Initialize the logging framework (e.g., Serilog, NLog, etc.) here
            _logger = new Serilog.LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public void LogInformation(string message)
        {
            _logger.Information(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogError(string message, Exception ex)
        {
            _logger.Error(ex, message);
        }
    }
}
