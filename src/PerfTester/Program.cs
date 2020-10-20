using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PerfTester
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Perf tester started");

            var path = Path.Combine(AppContext.BaseDirectory, "configs");
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddKeyPerFile(directoryPath: path, optional: true)
#if DEBUG
                .AddUserSecrets<Program>()
#endif
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var placeholder = configuration.GetValue<string>("placeholder");

            using var client = new HttpClient();
            var json = await client.GetStringAsync(placeholder);
        }
    }
}
