using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Walmart.SIEP.Productos.Helpers {
    public static class StringHelper {
        public static string GetDescription(Enum value) {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                ?? value.ToString();
        }
    }
}
