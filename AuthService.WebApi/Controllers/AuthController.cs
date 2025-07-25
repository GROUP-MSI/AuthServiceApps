using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    public AuthController(ILogger<AuthController> logger)
    {
      _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> AuthLogin()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }

    [HttpPost("register")]
    public async Task<IActionResult> AuthRegister()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }

    [HttpPost("2fa/email")]
    public async Task<IActionResult> TwoFactorOfAuthEmail()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }

    [HttpPost("2fa/sms")]
    public async Task<IActionResult> TwoFactorOfAuthSms()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }
    
    [HttpPost("2fa/verify")]
    public async Task<IActionResult> TwoFactorOfAuthVerify()
    {
      try
      {
        return Ok("");
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);       
      }
    }
  }
}