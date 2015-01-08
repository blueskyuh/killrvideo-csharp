using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KillrVideo.Utils;
using KillrVideo.Utils.Configuration;
using Nimbus;
using Nimbus.Configuration;
using Nimbus.Infrastructure;
using Nimbus.Logger.Serilog;
using Nimbus.Windsor.Configuration;

namespace KillrVideo.BackgroundWorker.Startup
{
    /// <summary>
    /// Installs Nimbus components with Castle Windsor.
    /// </summary>
    public class NimbusWindsorInstaller : IWindsorInstaller
    {
        private const string AzureServiceBusConnectionStringKey = "AzureServiceBusConnectionString";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Create the Nimbus type provider to scan all the application's assemblies and register appropriate classes with the container
            var appAssembly = typeof(NimbusWindsorInstaller).Assembly;
            var typeProvider = new AssemblyScanningTypeProvider(appAssembly.GetReferencedApplicationAssemblies().ToArray());
            container.RegisterNimbus(typeProvider);

            // Register the bus itself and its logger
            container.Register(
                Component.For<ILogger>().ImplementedBy<SerilogStaticLogger>().LifestyleSingleton(),
                Component.For<IBus, Bus>().UsingFactoryMethod(() => CreateBus(container, typeProvider)).LifestyleSingleton()
            );
        }

        private static Bus CreateBus(IWindsorContainer container, ITypeProvider typeProvider)
        {
            var configRetriever = container.Resolve<IGetEnvironmentConfiguration>();
            try
            {
                // Get the Azure Service Bus connection string, app name, and unique name for this running instance
                string connectionString = configRetriever.GetSetting(AzureServiceBusConnectionStringKey);
                string appName = configRetriever.AppName;
                string uniqueName = configRetriever.UniqueInstanceId;

                Bus bus = new BusBuilder().Configure()
                                          .WithConnectionString(connectionString)
                                          .WithNames(appName, uniqueName)
                                          .WithJsonSerializer()
                                          .WithWindsorDefaults(container)
                                          .WithTypesFrom(typeProvider)
                                          .Build();
                return bus;
            }
            finally
            {
                container.Release(configRetriever);
            }
        }
    }
}