using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Poc_ResponseCompression_And_RateLimit.Domain;
using Poc_ResponseCompression_And_RateLimit.Interfaces;

namespace Poc_ResponseCompression_And_RateLimit.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DividaController : ControllerBase
{
    private readonly IDividaService dividaService;

    public DividaController(IDividaService dividaService)
    {
        this.dividaService = dividaService;
    }

    [HttpGet]
    [EnableRateLimiting("FixedWindowRateLimiter")]
    public ActionResult<DividaDto> Get()
    {
        return Ok(this.dividaService.GetDividaDto());
    }
}
