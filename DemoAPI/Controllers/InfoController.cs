using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers;

public class InfoController : ControllerBase
{
    [HttpGet("/info")]
    public async Task<ActionResult> GetTheInfo()
    {
        return Ok("The Controller is working, thanks for trying");
    }
}
