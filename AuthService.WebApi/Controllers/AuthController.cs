using AuthService.Application.DTOs;
using AuthService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  [Route("api/v1/auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userServ;
    private readonly ISender _sender;
    // private readonly IMappper
    public AuthController(ILogger<AuthController> logger, ISender sender, IUserService userServ)
    {
      _logger = logger;
      _sender = sender;
      _userServ = userServ;
    }

    // [HttpPost("login")]
    // public async Task<IActionResult> AuthLogin()
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

    [HttpPost("register")]
    public async Task<IActionResult> AuthRegister([FromBody] RegisterUserRequestDto request)
    {
      try
      {
        var command = _userServ.MapToCommand(request);
        var userId = await _sender.Send(command);

        return CreatedAtAction(
          actionName: nameof(UserController.GetUser),
          controllerName: "user",
          routeValues: new { id = userId },
          value: userId
        );
      }
      catch (Exception err)
      {
        _logger.LogError(err.Message);
        return BadRequest(err.Message);
      }
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