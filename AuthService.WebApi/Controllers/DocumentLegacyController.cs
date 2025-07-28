using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  [Route("api/v1/document-legacy")]
  [ApiController]
  public class DocumentLegacyController : ControllerBase
  {
    private readonly ILogger<DocumentLegacyController> _logger;
    public DocumentLegacyController(ILogger<DocumentLegacyController> logger)
    {
      _logger = logger;
    }

    
  }
}