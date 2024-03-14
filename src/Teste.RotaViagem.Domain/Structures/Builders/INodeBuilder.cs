namespace Teste.RotaViagem.Domain.Structures;

public interface INodeBuilder
{
    INodeBuilder Create(string nodeName);
    INodeBuilder LinkTo(string otherNodeName, decimal weight);
    Node Build();
    INodeBuilder Clear();
}
