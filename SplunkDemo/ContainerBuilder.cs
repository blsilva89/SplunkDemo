using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace SplunkDemo
{
    public static class ContainerBuilder
    {
        public static IServiceProvider Configurar()
        {
            var colecaoServico = new ServiceCollection();
            var config = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                   .Build();

            NLog.LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
            colecaoServico.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
                logging.AddNLog();                
            });

            return colecaoServico.BuildServiceProvider();
        }
    }
}
