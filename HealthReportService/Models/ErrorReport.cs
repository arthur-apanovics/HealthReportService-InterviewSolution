using System;

namespace HealthReportService.Models
{
    [Serializable]
    public class ErrorReport
    {
        public string Source { get; set; }
        public string Message { get; set; }
    }
}