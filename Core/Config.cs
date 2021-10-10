using Core.Configuration;
using Core.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Core
{
    public static class Config
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR();
            services.AddScoped<IQueryBus, QueryBus>();

        }
    }
}
