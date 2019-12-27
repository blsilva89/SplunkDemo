using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SplunkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IServiceProvider provedorServico = ContainerBuilder.Configurar();

            var logger = provedorServico.GetService<ILogger<Program>>();

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;
            logger.LogInformation("Processed {@Position} in {Elapsed:000} ms.", position, elapsedMs);

            //var data = DateTime.Now.Date.ToString("dd/MM/yyyy");

            //logger.LogInformation("We are logging in splunk {data}!", data);
            //logger.LogWarning("Logging a warning to test!");
        }
    }
}
