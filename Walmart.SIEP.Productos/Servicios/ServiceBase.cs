using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using Walmart.SIEP.Productos.Models.Response;

namespace Walmart.SIEP.Productos.Servicios {
    public class ServiceBase {
        public readonly TelemetryClient _telemetry;

        public ServiceBase(TelemetryClient telemetry) {
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
        }

        public ResultResponse RegisterException(Exception ex) {
            var telemetry = new ExceptionTelemetry(ex) {
                ProblemId = Guid.NewGuid().ToString()
            };
            _telemetry.TrackException(telemetry);
            ResultResponse obj = new ResultResponse {
                IdError = telemetry.ProblemId,
                Data = "Error"
            };
            return obj;
        }
    }
}
