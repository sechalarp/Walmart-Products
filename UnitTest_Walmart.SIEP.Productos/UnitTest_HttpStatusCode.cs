using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Net;
using Walmart.SIEP.Productos.Controllers;

namespace UnitTest_Walmart.SIEP.Productos {
    public class UnitTest_HttpStatusCode {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void StatusCodeOK() {
            //Arrange
            TelemetryClient telemetry = new TelemetryClient();
            ProductosController productos = new ProductosController(telemetry);

            //Act
            var response = productos.ObtenerProductos("2");

            //Assert
            Assert.AreEqual(Convert.ToInt32(HttpStatusCode.OK), ((ObjectResult)response.Result).StatusCode);
        }
    }
}