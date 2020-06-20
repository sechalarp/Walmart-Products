using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Walmart.SIEP.Productos.Controllers {
    public class BaseController : Controller {
        public readonly TelemetryClient _telemetry;

        public BaseController(TelemetryClient telemetry) {
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
        }
    }
}
