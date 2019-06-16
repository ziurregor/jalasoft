namespace Jalasoft.Eva.Evaluations.Api.Server
{
    using System;
    using System.Configuration;
    using Jalasoft.Eva.Core.Logger;

    public class Program
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            try
            {
                var url = ConfigurationManager.AppSettings["apiUrl"];
                ConsoleAppRunner.ExecuteApi(url);
            }
            catch (Exception ex)
            {
                Log.Error("Could not start the application {0}");
                throw ex;
            }
        }
    }
}
