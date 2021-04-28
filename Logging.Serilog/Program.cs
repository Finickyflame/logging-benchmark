using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using WebApi;

namespace Logging.Serilog
{
    public class Program
    {
        public static void Main(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .UseSerilog((context, _, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
            )
            .Build()
            .Run();
    }
}
