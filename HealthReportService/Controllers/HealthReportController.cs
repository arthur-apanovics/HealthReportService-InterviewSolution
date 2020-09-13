using HealthReportService.Interfaces;
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
        private readonly IStorageService _storageService;

        /// <summary>
        /// API controller for Health Report related operations
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="storageService">Service for storing POSTed data, e.g. HealthReport</param>
        public HealthReportController(ILogger<HealthReportController> logger, IStorageService storageService)
        {
            _logger = logger;
            _storageService = storageService;
        }

        /// <summary>
        /// Receives and stores HealthReport objects
        /// </summary>
        /// <param name="healthReport"></param>
        /// <returns></returns>
        [HttpPost]
        public StatusCodeResult PostMyHealth(HealthReport healthReport)
        {
            if (!ModelState.IsValid || healthReport == null)
            {
                return BadRequest();
            }

            StorePostedData("HealthReport", healthReport);
            
            _logger.Log(
                LogLevel.Information,
                $"Received {nameof(HealthReport)} from {Request.HttpContext.Connection.RemoteIpAddress}");

            return Ok();
        }

        private void StorePostedData(string destination, object data)
        {
            _storageService.Write(destination, data);
        }
    }
}