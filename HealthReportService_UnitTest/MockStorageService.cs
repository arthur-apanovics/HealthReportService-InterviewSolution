using System.Threading.Tasks;
using HealthReportService.Interfaces;
using Microsoft.Extensions.Logging;

namespace HealthReportService_UnitTest
{
    public class MockStorageService : IStorageService
    {
        private readonly ILogger<MockStorageService> _logger;
        
        public MockStorageService(ILogger<MockStorageService> logger)
        {
            _logger = logger;
        }
        
        public Task Write<T>(string destination, T dataObject) where T : new()
        {
            _logger.Log(LogLevel.Information, $"Pretending to write {typeof(T)} to '{destination}'...");

            return Task.CompletedTask;
        }
    }
}