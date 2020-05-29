using Jerry.Prateice.Autofac.IServices;
using Microsoft.Extensions.Logging;
using System;

namespace Jerry.Prateice.Autofac.Services
{
    public class ServiceB : IServiceB
    {
        private ILogger _logger;

        public ServiceB(ILogger logger)
        {
            _logger = logger;
        }

        public void DoSomething()
        {
            _logger.LogInformation("ServerB 做了一些事情");
        }
    }
}
