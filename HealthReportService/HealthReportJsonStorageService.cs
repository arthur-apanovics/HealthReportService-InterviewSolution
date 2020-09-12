using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace HealthReportService
{
    internal class HealthReportJsonStorageService : JsonFileStorageServiceBase
    {
        protected override string Directory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

        public HealthReportJsonStorageService(ILogger<HealthReportJsonStorageService> logger) : base(logger)
        {
        }
    }
}