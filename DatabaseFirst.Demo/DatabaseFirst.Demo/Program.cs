using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace DatabaseFirst.Demo
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

            Console.WriteLine("Hello World!");
            WaitHandle.WaitOne();
        }
    }
}
