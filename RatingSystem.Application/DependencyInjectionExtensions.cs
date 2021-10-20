using Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RatingSystem.Application.WriteOperations;
using static RatingSystem.Application.Queries.ListOfRatings;

namespace RatingSystem.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Data.RatingDbContext>();

            return services;
        }
    }
}
