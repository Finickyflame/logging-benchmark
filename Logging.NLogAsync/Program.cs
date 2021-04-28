using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using WebApi;

namespace NLogColoredLogging
{
    public class Program
    {
        public static void Main(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>  webBuilder.UseStartup<Startup>())
            .ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders())
            .UseNLog()
            .Build()
            .Run();
    }
}