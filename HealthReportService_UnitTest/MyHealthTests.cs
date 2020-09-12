using System.Net;
using HealthReportService.Controllers;
using HealthReportService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Xunit.Abstractions;

namespace HealthReportService_UnitTest
{
    public class MyHealthTests
    {
        private readonly HealthReportController _healthReportController;

        public MyHealthTests(ITestOutputHelper output)
        {
            var mockStorage = new MockStorageService(new XunitLogger<MockStorageService>(output));
            _healthReportController = new HealthReportController(
                new XunitLogger<HealthReportController>(output), mockStorage)
                {
                // controller relies on Request object for some logging
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                    {
                        Connection =
                        {
                            Id = "xUnit",
                            RemoteIpAddress = new IPAddress(new byte[] {0, 0, 0, 0}),
                            LocalIpAddress = new IPAddress(new byte[] {127, 0, 0, 1}),
                        }
                    }
                }
            };
        }

        [Fact]
        public void PostMyHealthTest()
        {
            // Arrange
            var report = new HealthReport()
            {
                Token = 1,
                RegistrationCode = "X345-236-8919640628",
                Title = "Busfinder Health Report",
                Version = "1053",
                Errors = new[]
                {
                    new ErrorReport
                    {
                        Source = "Power",
                        Message = "Low power warning"
                    },
                    new ErrorReport
                    {
                        Source = "Communications",
                        Message = "Network disconnected twice"
                    }
                },
                ButtonPresses = 6,
                Battery01VoltAvg = 5,
                Battery02VoltAvg = 4,
                ChargeCurrentAvg = 3,
                SunlightAvg = 2,
                CellBarAvg = 1
            };

            // Act
            var response = _healthReportController.PostMyHealth(report);

            // Assert
            Assert.Equal((int) HttpStatusCode.OK, response.StatusCode);
        }
    }
}