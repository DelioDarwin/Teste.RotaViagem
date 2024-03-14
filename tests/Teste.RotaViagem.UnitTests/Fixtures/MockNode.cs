using Teste.RotaViagem.Domain.Structures;
using Teste.RotaViagem.Domain.Travels;

namespace Teste.RotaViagem.UnitTests.Fixtures;

public class MockNode : Node
{
    public MockNode(Location Location) : base(Location, 0) {  }
}