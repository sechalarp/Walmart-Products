using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Walmart.SIEP.Productos.Helpers {
    public class AppSettingsHelper {
        public static IConfiguration Configuration { get; set; }
        static AppSettingsHelper() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings/appsettings.secrets.json");

            Configuration = builder.Build();
        }

        public static string GetKeyString(string name) {
            var output = Configuration[name];

            if (string.IsNullOrWhiteSpace(output))
                throw new Exception($"Key [{name}] es null o empty");

            return output;
        }

        public static int GetKeyInt(string name) {
            var output = Configuration[name];
            int value = 0;
            if (string.IsNullOrWhiteSpace(output))
                throw new Exception($"Key [{name}] es null o empty");

            if (!int.TryParse(output, out value))
                throw new Exception($"Value [{output}] no es número");

            return value;
        }
    }
}
