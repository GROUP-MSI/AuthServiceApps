using Microsoft.AspNetCore.Mvc;

namespace AuthService.WebApi.Controllers
{
  public class DocumentLegacyController : ControllerBase
  {
    private readonly ILogger<DocumentLegacyController> _logger;
    public DocumentLegacyController(ILogger<DocumentLegacyController> logger)
    {
      _logger = logger;
    }

    
  }
}