using Awarean.Sdk.Result;
using Teste.RotaViagem.Domain.Travels;

namespace Teste.RotaViagem.Domain.CheapestRouteCalculation
{
    public interface ICheapestTravelFinder
    {
        public Result<LinkedList<(string Location, decimal CostFromSource)>> FindShortestPath(Location startingPoint, Location destination, List<Travel> travels);
    }
}
