using System.Collections.Generic;

namespace HealthReportService.Models
{
    public class HealthReport
    {
        public int Token { get; set; }
        public string RegistrationCode { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public IEnumerable<ErrorReport> Errors { get; set; }
        public int ButtonPresses { get; set; }
        public int Battery01VoltAvg { get; set; }
        public int Battery02VoltAvg { get; set; }
        public int ChargeCurrentAvg { get; set; }
        public int SunlightAvg { get; set; }
        public int CellBarAvg { get; set; }
    }
}