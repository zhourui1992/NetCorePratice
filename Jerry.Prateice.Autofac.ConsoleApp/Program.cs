using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Jerry.Prateice.Autofac.IServices;
using Jerry.Prateice.Autofac.Services;
using Jerry.Prateice.EF.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Linq;

namespace Jerry.Prateice.Autofac.ConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // The `UseServiceProviderFactory(new AutofacServiceProviderFactory())` call here allows for
            // ConfigureContainer to be supported with
            // a strongly-typed ContainerBuilder. If you don't
            // have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())` here, you won't get
            // ConfigureContainer support. This also automatically
            // calls Populate to put services you register during
            // ConfigureServices into Autofac.
            await Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureServices(ConfigureServices)
                .ConfigureContainer<ContainerBuilder>(ConfigureContainer)
                .RunConsoleAsync();
        }


//        None of the constructors found with 'Autofac.Core.Activators.Reflection.DefaultConstructorFinder' on type 'Jerry.Prateice.Autofac.ConsoleApp.LocalHostedService' can be invoked with the available services and parameters:
//Cannot resolve parameter 'Jerry.Prateice.Autofac.ConsoleApp.LocalService.TestService testService' of constructor 'Void .ctor(Jerry.Prateice.Autofac.IServices.IServiceA, Jerry.Prateice.Autofac.ConsoleApp.LocalService.TestService)'.
        private static void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // Use extensions from libraries to register services in the
            // collection. These will be automatically added to the
            // Autofac container.

            containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
            containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            containerBuilder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes().Where(c => c.Name.StartsWith("Test")).ToArray()).InstancePerLifetimeScope();

        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to `UseServiceProviderFactory(new AutofacServiceProviderFactory())`
            // when building the host or this won't be called.
            services.AddHostedService<LocalHostedService>();
            services.AddDbContext<LocalDbContext>(options =>
            {
                options.UseMySql(context.Configuration.GetSection("MySqlConn").Value);
            });
        }
    }
}
