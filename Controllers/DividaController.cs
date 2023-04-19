using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Poc_ResponseCompression_And_RateLimit.Domain;

namespace Poc_ResponseCompression_And_RateLimit.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DividaController : ControllerBase
{
    [HttpGet]
    [EnableRateLimiting("FixedWindowRateLimiter")]
    public ActionResult<DividaDto> Get()
    {
        return Ok(new DividaDto());
    }
}
