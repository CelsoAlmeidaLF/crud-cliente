using Microsoft.Extensions.DependencyInjection;

using Almeida.Core.Interfaces;
using Almeida.Core.Entities;
using Almeida.Application.Business;

namespace Almeida.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<Cliente>, BusinessCliente>();
            return services;
        }

        //public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        //    services.AddDbContext<AppDbContext>(options =>
        //        options.UseSqlServer(connectionString));
    }
}
