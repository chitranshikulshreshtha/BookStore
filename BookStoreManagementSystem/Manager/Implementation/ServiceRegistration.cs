using BookManagement.Manager.Implementation;
using BookManagement.Manager.Interfaces;
using BookManagement.BusinessModels;
using BookManagement.Managers.Implementation;
using BookManagement.Managers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;

namespace BookManagement.Managers
{
    public static class ServiceRegistration
    {
        /// <summary>
        /// Extension method to add the dependancy
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseSettings>(x => x.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<IDbConnectionManager, DbConnectionManager>();
         //   services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddSingleton<IDbConnectionManager, DbConnectionManager>();
            services.AddScoped<IBookStoreManager, BookStoreManager>();

        }
    }
}
