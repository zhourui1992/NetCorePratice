using log4net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jerry.Prateice.Autofac.ConsoleApp
{
    public class Test2Service
    {
        ILogger<Test2Service> _logger;

        public Test2Service(ILogger<Test2Service> logger)
        {
            _logger = logger;
        }

        public void Show()
        {
            _logger.LogInformation("Test2Service is showing");
        }
    }
}
