using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  public class UserController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly ISender _sender;
    public UserController(ILogger<AuthController> logger, ISender sender)
    {
      _logger = logger;
      _sender = sender;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
      // var query = new GetUserByIdQuery(id);
      // var user = await _sender.Send(query);
      return Ok("user");
    }

  }
}