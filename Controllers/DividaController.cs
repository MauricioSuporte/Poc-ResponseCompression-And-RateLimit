using Microsoft.AspNetCore.Mvc;
using Poc_ResponseCompression_And_RateLimit.Domain;

namespace Poc_ResponseCompression_And_RateLimit.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DividaController : ControllerBase
{
    [HttpGet]
    public IEnumerable<DividaDto> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new DividaDto
        {
            DataLimiteNegociacao = DateTime.Now.AddDays(index),
            ValorTotal = (decimal)Random.Shared.NextDouble() * 100,
        })
        .ToArray();
    }
}
