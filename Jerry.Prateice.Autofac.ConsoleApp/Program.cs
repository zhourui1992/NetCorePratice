using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Jerry.Prateice.Autofac.ConsoleApp
{
    class Program
    {
        async static void Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(ConfigureServices)
                .ConfigureContainer<ContainerBuilder>(ConfigureContainer)
                .RunConsoleAsync();
        }

        private static void ConfigureContainer(ContainerBuilder containerBuilder)
        {

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<LocalHostedService>();
        }
    }
}
