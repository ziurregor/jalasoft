namespace Jalasoft.Eva.Evaluations.Api.Server
{
    using System;
    using System.IO;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Api.Rest.AppStart;
    using Microsoft.AspNetCore.Hosting;

    internal class ConsoleAppRunner
    {
        private const string LOGO = @"
  ______          _             _   _                    _____                 _          
 |  ____|        | |           | | (_)                  / ____|               (_)         
 | |____   ____ _| |_   _  __ _| |_ _  ___  _ __  ___  | (___   ___ _ ____   ___  ___ ___ 
 |  __\ \ / / _` | | | | |/ _` | __| |/ _ \| '_ \/ __|  \___ \ / _ | '__\ \ / | |/ __/ _ \
 | |___\ V | (_| | | |_| | (_| | |_| | (_) | | | \__ \  ____) |  __| |   \ V /| | (_|  __/
 |______\_/ \__,_|_|\__,_|\__,_|\__|_|\___/|_| |_|___/ |_____/ \___|_|    \_/ |_|\___\___|

";

        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(ConsoleAppRunner));

        public static void ExecuteApi(string url)
        {
            Console.WriteLine("Starting evaluations API service.");
            Console.WriteLine(LOGO);
            Console.WriteLine("Running on {0}", url);
            Log.Info(string.Format("Running on {0}", url));
            Console.WriteLine("REST API documentation on {0}/docs", url);

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls(urls: url)
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
