using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Demo.WebService.Core.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Demo.WebService
{
    public class Program
    {
        // private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            // var log4netConfig = new System.Xml.XmlDocument();
            // log4netConfig.Load(File.OpenRead("Configurations\\log4net.config"));

            // var repo = log4net.LogManager.CreateRepository(
            //     System.Reflection.Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            // log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            // log.Info("Application - Main is invoked");

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((webHostBuilder, config) =>
            {
                var env = webHostBuilder.HostingEnvironment;
                config.SetBasePath(Path.Combine(env.ContentRootPath, "Configurations"))
                        .AddJsonFile("DBConnections.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //.AddJsonFile($"\\Configuration\\appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            })
            .ConfigureLogging((hostContext, logging) =>
            {
                logging.AddProvider(new Log4NetProvider("Configurations\\log4net.config"));
            })
            .UseStartup<Startup>()
            .Build();
    }
}
