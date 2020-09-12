using System;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HealthReportService;
using HealthReportService.Controllers;
using Xunit;

namespace HealthReportService_UnitTest
{
    public class MyHealthIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public MyHealthIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        private static Uri GetHealthReportEndpointUriForAction(string action)
        {
            return new Uri($"api/HealthReport/{action}", UriKind.Relative);
        }

        [Fact]
        public async Task PostMyHealthTest()
        {
            // Arrange
            var postObject = new
            {
                Token = 1,
                RegistrationCode = "X345-236-8919640628",
                Title = "Busfinder Health Report",
                Version = "1053",
                Errors = new object[]
                {
                    new
                    {
                        Source = "Power",
                        Message = "Low power warning"
                    },
                    new
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
            var content = new StringContent(
                JsonSerializer.Serialize(postObject), Encoding.UTF8, MediaTypeNames.Application.Json);

            // Act
            var uri = GetHealthReportEndpointUriForAction(nameof(HealthReportController.PostMyHealth));
            var response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}