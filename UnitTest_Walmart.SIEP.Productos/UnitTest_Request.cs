using Microsoft.ApplicationInsights;
using NUnit.Framework;
using Walmart.SIEP.Productos.Models.Response;
using Walmart.SIEP.Productos.Servicios;

namespace UnitTest_Walmart.SIEP.Productos {
    public class UnitTest_Request {
        public void Setup() {
        }

        [Test]
        public void ValidateRequestToApi() {
            //Arrange
            string palabraRequest = "asdf";
            TelemetryClient telemetry = new TelemetryClient();
            ValidarRequestService validacionRequest = new ValidarRequestService(telemetry);
            //Act
            ResultResponse resultData = validacionRequest.CheckRequest(palabraRequest);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(resultData.MessageError));
        }
    }
}
