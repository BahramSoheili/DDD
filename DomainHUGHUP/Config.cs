using MediatR;
using Microsoft.Extensions.DependencyInjection;
using DomainHUGHUP.Handlers.QueryHandlers;
using DomainHUGHUP.Queries;
using Core.Queries;

namespace DomainHUGHUP
{
    public static class Config
    {
        public static void AddConfigHUGHUB(this IServiceCollection services)
        {
            services.AddPersonScope();          
        }
        private static void AddPersonScope(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetPrice, decimal>, PersonQueryHandler>();
        }
    }
}
