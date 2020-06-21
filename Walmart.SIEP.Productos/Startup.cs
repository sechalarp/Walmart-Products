using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Walmart.SIEP.Productos.Helpers;
using Walmart.SIEP.Productos.Middleware;

namespace Walmart.SIEP.Productos {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            var instrumentationKey = AppSettingsHelper.GetKeyString("ApplicationInsights:InstrumentationKey");
            services.AddApplicationInsightsTelemetry(instrumentationKey);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(config => {
                config.SwaggerDoc("v1", new Info {
                    Title = "Prueba técnica Walmart - Amaris",
                    Version = "V1",
                    Description = "API para consultar productos desde una BD Mongo",
                    Contact = new Contact {
                        Name = "Sebastián Echalar Peñailillo",
                        Url = "https;//www.linkedin.com/in/sechalarp",
                        Email = "sechalarp@icloud.com"
                    }
                });
            });

            services.AddHttpClient();
            services.AddCors(options => {
                options.AddPolicy("default", builder => {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseSwagger();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }
            app.UseMiddleware<ErrorWrappingMiddleware>();
            app.UseStaticFiles(new StaticFileOptions {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Swagger")),
                RequestPath = "/Swagger"
            });
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("/swagger/swagger.json", "v1.0");
                config.RoutePrefix = "swagger/swagger";
            });

            app.UseCors("default");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
