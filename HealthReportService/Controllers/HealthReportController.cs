using HealthReportService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HealthReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HealthReportController : ControllerBase
    {
        private readonly ILogger<HealthReportController> _logger;

        public HealthReportController(ILogger<HealthReportController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public StatusCodeResult PostMyHealth(HealthReport healthReport)
        {
            if (!ModelState.IsValid || healthReport == null)
            {
                return BadRequest();
            }

            // TODO: write to file
            
            _logger.Log(
                LogLevel.Information,
                $"Received {nameof(HealthReport)} from {Request.HttpContext.Connection.RemoteIpAddress}");

            return Ok();
        }
    }
}