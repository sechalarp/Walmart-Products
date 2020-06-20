using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Walmart.SIEP.Productos.Exceptions;
using Walmart.SIEP.Productos.Models.Response;

namespace Walmart.SIEP.Productos.Middleware {
    public class ErrorWrappingMiddleware {
        private readonly RequestDelegate _next;
        private readonly TelemetryClient _telemetry;

        public ErrorWrappingMiddleware(RequestDelegate next, TelemetryClient telemetry) {
            _next = next;
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next.Invoke(context);
            } catch (ProductosException ex) {
                var telemetry = new ExceptionTelemetry(ex) {
                    ProblemId = Guid.NewGuid().ToString()
                };

                _telemetry.TrackException(telemetry);

                var response = new ErrorResponse() { Id = telemetry.ProblemId };
                var json = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            } catch (Exception ex) {
                var telemetry = new ExceptionTelemetry(ex) {
                    ProblemId = Guid.NewGuid().ToString()
                };

                _telemetry.TrackException(telemetry);

                var response = new ErrorResponse() { Id = telemetry.ProblemId };
                var json = JsonConvert.SerializeObject(response);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
        }
    }
}
