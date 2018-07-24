using Microsoft.AspNetCore.Mvc;

namespace Batman.API.Controllers
{
    public class GadgetsController
    {
        [Route("gadgets")]
        public IActionResult GetGadgets()
        {
            return new OkObjectResult(new { items = new[]
            {
                "Batarangs",
                "Sonar",
                "Batcall",
                "Grappling hook"
            } });
        }
    }
}