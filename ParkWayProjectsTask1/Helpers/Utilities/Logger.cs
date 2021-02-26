using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProjectsTask1.Helpers.Utilities
{
    public class Logger
    {
        private readonly ILogger _logger;
        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        public void logException(Exception exMessage)
        {
            _logger.LogInformation(string.Format("This Error: {0}, Occurred at {1}; Source: {2}", exMessage.Message, exMessage.StackTrace, exMessage.Source));
        }
    }
}
