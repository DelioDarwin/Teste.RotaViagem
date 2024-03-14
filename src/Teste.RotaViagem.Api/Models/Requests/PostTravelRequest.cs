using Microsoft.AspNetCore.Mvc;

namespace Teste.RotaViagem.Api.Models.Requests;

public class PostTravelRequest
{
    public string StartingPoint { get; set; }
    public string Destination { get; set; }
    public decimal Amount { get; set; }
}
