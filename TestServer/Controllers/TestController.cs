using System.Threading;
using Etogy.Settlement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etogy.Settlement.API.Controllers {
  [ApiController]
  [Route("api/[controller]")]
  public class TestController : ControllerBase {
    [HttpPost("withToken")]
    public IActionResult PostWithToken(TransactionCollection request, CancellationToken token) {
      return Ok(new { IsValid = ModelState.IsValid, MaxErrorsReached = ModelState.HasReachedMaxErrors, Errors = ModelState.ErrorCount });
    }

    [HttpPost("noToken")]
    public IActionResult PostWithoutToken(TransactionCollection request) {
      return Ok(new { IsValid = ModelState.IsValid, MaxErrorsReached = ModelState.HasReachedMaxErrors, Errors = ModelState.ErrorCount });
    }
  }
}