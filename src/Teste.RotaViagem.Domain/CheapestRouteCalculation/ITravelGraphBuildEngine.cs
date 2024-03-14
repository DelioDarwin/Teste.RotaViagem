using Awarean.Sdk.Result;
using Teste.RotaViagem.Domain.Structures;
using Teste.RotaViagem.Domain.Travels;

namespace Teste.RotaViagem.Domain.CheapestRouteCalculation;

public interface ITravelGraphBuildEngine
{
    Result<DirectedGraph> BuildGraph(IEnumerable<Travel> travelList);
}
