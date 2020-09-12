### Coding challenge for Connexionz

The task is to be returned to me by 9am 15th Sept 2020 as a zipped Visual Studio solution that can be opened , built, and tested without requiring any changes to the projects or solution.

The task is to create a .NET Core 3.1 web API that receives a JSON structure (HealthReport), deserializes this structure, and saves the content to a local file.

The web API solution name is HealthReportSolution.
The project name is HealthReportService and the output file is named HealthReport.json
The associated xUnit Test project is named HealthReportService_UnitTest.

DETAILS
JSON structure (HealthReport)
```
{
  "Token": 1,
  "RegistrationCode": "X345-236-8919640628",
  "Title": "Busfinder Health Report",
  "Version": "1053",
  "Errors": [
    {
      "Source": "Power",
      "Message": "Low power warning"
    },
    {
      "Source": "Communications",
      "Message": "Network disconnected twice"
    }
  ],
  "ButtonPresses": 6,
  "Battery01VoltAvg": 5,
  "Battery02VoltAvg": 4,
  "ChargeCurrentAvg": 3,
  "SunlightAvg": 2,
  "CellBarAvg": 1
}
```

Web API (HealthReportService)
.NET Core 3.1
One REST POST Method – PostMyHealth
One private method to write the contents of the POST to a new file named HealthReport.json output to the same folder path that the API is executed from.
The method PostMyHealth returns a status code

xUnit Test Project (HealthReportService_UnitTest)
Same framework as HealthReportService project
The Unit Test method will have the [Fact] Attribute applied to it
The class name is MyHealthTests
The method name is PostMyHealthTest
The method assertion is based on the status code returned… Assert.Equal(expected value, returned value)
