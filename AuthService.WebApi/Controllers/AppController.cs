using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  public class AppController : ControllerBase
  {

    private readonly ILogger<AppController> _logger;
    public AppController(ILogger<AppController> logger)
    {
      _logger = logger;
    }


    // [HttpPost]
    // public async Task<IActionResult> CreateApp()
    // {
    //   try
    //   {
    //     return Ok("");
    //   }
    //   catch (Exception err)
    //   {
    //     _logger.LogError(err.Message);
    //     return BadRequest(err.Message);
    //   }
    // }

    // [HttpPatch]
    // public async Task<IActionResult> UpdateApp()
    // {
    //   try
    //   {
    //     return Ok("");
    //   }
    //   catch (Exception err)
    //   {
    //     _logger.LogError(err.Message);
    //     return BadRequest(err.Message);
    //   }
    // }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteApp()
    // {
    //   try
    //   {
    //     return Ok("");
    //   }
    //   catch (Exception err)
    //   {
    //     _logger.LogError(err.Message);
    //     return BadRequest(err.Message);
    //   }
    // }

    // [HttpGet]
    // public async Task<IActionResult> GetApps()
    // {
    //   try
    //   {
    //     return Ok("");
    //   }
    //   catch (Exception err)
    //   {
    //     _logger.LogError(err.Message);
    //     return BadRequest(err.Message);
    //   }
    // }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetApp(int id)
    // {
    //   try
    //   {
    //     return Ok("");
    //   }
    //   catch (Exception err)
    //   {
    //     _logger.LogError(err.Message);
    //     return BadRequest(err.Message);
    //   }
    // }
  }
}