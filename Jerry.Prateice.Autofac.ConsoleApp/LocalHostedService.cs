using Jerry.Prateice.Autofac.IServices;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Jerry.Prateice.Autofac.ConsoleApp
{
    public class LocalHostedService : IHostedService
    {

        IServices.IServiceA _serviceA;
        TestService _testService;

        public LocalHostedService(IServiceA serviceA, TestService testService)
        {
            _serviceA = serviceA;
            _testService = testService;
        }

        //public LocalHostedService(IServices.IServiceA serviceA)
        //{
        //    _serviceA = serviceA;
        //}
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _testService.Show();
            _serviceA.DoAddStudent();
            return Task.CompletedTask;
            //throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("222");
            return Task.CompletedTask;
        }
    }
}
