using log4net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jerry.Prateice.Autofac.ConsoleApp
{
    public class TestService
    {
        ILogger<TestService> _logger;
        Test2Service _test2Service;
        public TestService(ILogger<TestService> logger, Test2Service test2Service)
        {
            _logger = logger;
            _test2Service = test2Service;
        }

        public void Show()
        {
            _test2Service.Show();
            _logger.LogInformation("TestService is showing");
        }
    }
}
