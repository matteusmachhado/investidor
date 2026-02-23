

using Microsoft.AspNetCore.Mvc;

namespace Investidor.WebApi.Controllers
{
    [Route("api/asset")]
    public class AssetController : ApiControllerBase 
    {
        public AssetController() { }

        [HttpGet("ping")]
        public async Task<ActionResult> ping()
        { 
            return Ok("pong");
        }
    }
}
