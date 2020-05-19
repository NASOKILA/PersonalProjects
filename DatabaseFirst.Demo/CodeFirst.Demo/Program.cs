using CodeFirst.Demo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;

namespace CodeFirst.Demo
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        
        private static readonly AutoResetEvent WaitHandle = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var serviceProvider = SetupDependencies();

            Object s = new Object() { };
            s.

            Console.WriteLine("Database ready");
            WaitHandle.WaitOne();
        }

        private static ServiceProvider SetupDependencies()
        {
            var services = new ServiceCollection()
                .AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("DbConnect")), ServiceLifetime.Transient)
                .AddLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddFilter("Microsoft", LogLevel.Warning);
                });

            return services.BuildServiceProvider();
        }
    }
}
