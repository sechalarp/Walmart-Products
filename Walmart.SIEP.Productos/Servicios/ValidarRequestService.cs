using Microsoft.ApplicationInsights;
using System;
using Walmart.SIEP.Productos.Exceptions;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Models.Enums;
using Walmart.SIEP.Productos.Models.Response;

namespace Walmart.SIEP.Productos.Servicios {
    internal class ValidarRequestService : ServiceBase{
        internal ValidarRequestService(TelemetryClient telemetry) : base(telemetry) { }

        internal ResultResponse CheckRequest(string palabra) {
			try {
                if (string.IsNullOrEmpty(palabra))
                    throw new ValidarRequestException(StringHelper.GetDescription(EMessages.EMessageProductNullOrEmpty));

                if (!int.TryParse(palabra, out _) && palabra.Length < 4)
                    throw new ValidarRequestException(StringHelper.GetDescription(EMessages.EMessageNameProductoTooShort));

                ResultResponse objResult = new ResultResponse {
                    MessageError = string.Empty
                };
                return objResult;
            } catch (ValidarRequestException ex) {
                string mensajeCliente = ex.Message.Split(":|")[1];
                ResultResponse result = RegisterException(ex);
                result.MessageError = mensajeCliente;
                return result;
            } catch (Exception ex) {
                return RegisterException(ex);
            }
        }
    }
}
