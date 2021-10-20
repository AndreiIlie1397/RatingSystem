using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace RatingSystem.WebApi.Swagger
{
    public static class SwaggerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="authority"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, string authority)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Rating Api",
                        Version = "v1"
                    }
                );

                c.CustomSchemaIds(type => type.ToString());
           
            });

            return services;
        }
    }
}
