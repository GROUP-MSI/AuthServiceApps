using AuthService.Application.DTOs;
using AuthService.Application.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  [Route("api/v1/auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userServ;
    private readonly IAuthService _service;
    public AuthController(ILogger<AuthController> logger, IUserService userServ, IAuthService service)
    {
      _logger = logger;
      _userServ = userServ;
      _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> AuthLogin(AuthRequestDto request)
    {
      try
      {
        var result = await _service.Login(request);
        return Ok(result);
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
    }

    [HttpPost("register")]
    public async Task<IActionResult> AuthRegister([FromBody] RegisterUserRequestDto request)
    {
      var result = await _service.RegisterUser(request);

      if (result.IsSuccess)
        return CreatedAtAction(
          actionName: nameof(UserController.GetUser),
          controllerName: "user",
          routeValues: new { id = result.Value.User.Id },
          value: result.Value
        );

      return BadRequest(new { Error = result.Errors });
    }

    // [HttpPost("refresh-token")]
    // public async Task<IActionResult> RefreshToken()
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

    // [HttpPost("2fa/email")]
    // public async Task<IActionResult> TwoFactorOfAuthEmail()
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

    // [HttpPost("2fa/sms")]
    // public async Task<IActionResult> TwoFactorOfAuthSms()
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

    // [HttpPost("2fa/verify")]
    // public async Task<IActionResult> TwoFactorOfAuthVerify()
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