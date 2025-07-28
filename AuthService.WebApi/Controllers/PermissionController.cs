using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  [Route("api/v1/permission")]
  [ApiController]
  public class PermissionController : ControllerBase
  {

    private readonly ILogger<PermissionController> _logger;
    public PermissionController(ILogger<PermissionController> logger)
    {
      _logger = logger;
    }

    // [HttpPost]
    // public async Task<IActionResult> CreatePermission()
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
    // public async Task<IActionResult> UpdatePermission()
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
    // public async Task<IActionResult> DeletePermission()
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
    // public async Task<IActionResult> GetPermissions()
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
    // public async Task<IActionResult> GetPermission(int id)
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