using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly ILogger<AuthController> _logger;
    private readonly ISender _sender;
    public UserController(ILogger<AuthController> logger, ISender sender)
    {
      _logger = logger;
      _sender = sender;
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
      // var query = new GetUserByIdQuery(id);
      // var user = await _sender.Send(query);
      return Ok("user");
    }

  }
}