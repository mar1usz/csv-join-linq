using CsvJoin.Services;
using CsvJoin.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

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
            AddServices(services);
            AddApplication(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<ILinqPreparator, LinqPreparator>();
        }

        private static void AddApplication(IServiceCollection services)
        {
            services.AddTransient<Application>();
        }
    }
}
