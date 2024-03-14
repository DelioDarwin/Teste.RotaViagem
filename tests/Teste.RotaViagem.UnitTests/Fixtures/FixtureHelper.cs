using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Teste.RotaViagem.Application.CheapestRouteCalculation;
using Teste.RotaViagem.Domain.CheapestRouteCalculation;
using Teste.RotaViagem.Domain.Structures;
using Teste.RotaViagem.Domain.Travels;

namespace Teste.RotaViagem.UnitTests.Fixtures;
public static class FixtureHelper
{
    public static List<Travel> GetTravelList() => new List<Travel>
    {
        new Travel(source: "GRU", destination: "BRC", amount: 1000),
        new Travel(source: "BRC", destination: "SCL", amount: 500),
        new Travel(source: "GRU", destination: "CDG", amount: 7500),
        new Travel(source: "GRU", destination: "SCL", amount: 2000),
        new Travel(source: "GRU", destination: "ORL", amount: 5600),
        new Travel(source: "ORL", destination: "CDG", amount: 500),
        new Travel(source: "SCL", destination: "ORL", amount: 2000),
    };

    public static HashSet<Location> GetPlaces() => new() { "GRU", "ORL", "BRC", "SCL", "CDG" };

    internal static ITravelGraphBuildEngine GetTravelGraphBuildEngine()
    {
        var nodeBuilder = new NodeBuilder();
        var graphBuilder = new GraphBuilder();
        var logger = Substitute.For<ILogger<TravelGraphBuildEngine>>();

        return new TravelGraphBuildEngine(graphBuilder, nodeBuilder, logger);
    }
}