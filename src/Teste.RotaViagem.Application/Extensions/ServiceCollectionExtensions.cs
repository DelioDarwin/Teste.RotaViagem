using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Teste.RotaViagem.Application.CheapestRouteCalculation;
using Teste.RotaViagem.Application.Travels.Services;
using Teste.RotaViagem.Domain.CheapestRouteCalculation;
using Teste.RotaViagem.Domain.Structures;
using Teste.RotaViagem.Domain.Travels;

namespace Teste.RotaViagem.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<ICheapestTravelFinder, CheapestTravelFinder>();

            services.AddBuilders();
            services.AddGraphEngines();

            return services;
        }

        public static IServiceCollection AddBuilders(this IServiceCollection services)
        {
            services.AddScoped<INodeBuilder, NodeBuilder>();
            services.AddScoped<IGraphBuilder, GraphBuilder>();

            return services;
        }

        public static IServiceCollection AddGraphEngines(this IServiceCollection services)
        {
            services.AddScoped<ITravelGraphBuildEngine, TravelGraphBuildEngine>();
            services.AddScoped<Action<string, object[]>>(x => x.GetRequiredService<ILogger>().LogInformation);
            return services;
        }
    }
}
