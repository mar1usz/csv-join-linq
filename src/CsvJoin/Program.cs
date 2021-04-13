using CsvJoin.Services;
using CsvJoin.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CsvJoin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetRequiredService<Application>().Run(args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILinqPreparator, LinqPreparator>();

            services.AddTransient<Application>();
        }
    }
}
