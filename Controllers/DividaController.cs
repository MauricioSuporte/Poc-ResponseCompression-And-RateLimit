using Microsoft.AspNetCore.Mvc;
using Poc_ResponseCompression_And_RateLimit.Domain;

namespace Poc_ResponseCompression_And_RateLimit.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DividaController : ControllerBase
{
    [HttpGet]
    public ActionResult<DividaDto> Get()
    {
        return Ok(new DividaDto());
    }
}
