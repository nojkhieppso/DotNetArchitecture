using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace Solution.CrossCutting.Logging
{
    public class Logger : ILogger
    {
        public Logger(IConfiguration configuration)
        {
            Log = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        private Serilog.ILogger Log { get; }

        public void Error(Exception exception)
        {
            Log.Error(exception, exception.Message);
        }
    }
}
