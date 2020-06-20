using System.ComponentModel;

namespace Walmart.SIEP.Productos.Models.Enums {
    public enum EMessages {
        [Description(":|El campo producto no puede estar vacío.")]
        EMessageProductNullOrEmpty = 1,
        [Description(":|El campo producto debe tener un largo mínimo de 4 caracteres.")]
        EMessageNameProductoTooShort = 2
    }
}
