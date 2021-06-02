using MagicOnion.Server;
using MagicOnion.Server.OpenTelemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddMagicOnion(options =>
                {
                    options.GlobalFilters.Add(new MagicOnionOpenTelemetryTracerFilterFactoryAttribute());
                    options.GlobalStreamingHubFilters.Add(new MagicOnionOpenTelemetryStreamingTracerFilterFactoryAttribute());

                    // Exception Filter is inside telemetry
                    options.GlobalFilters.Add(new ExceptionFilterFactoryAttribute());
                })
                .AddOpenTelemetry((options, provider, tracerBuilder) =>
                {
                    // Switch between Jaeger/Zipkin by setting UseExporter in appsettings.json.
                    var exporter = this.Configuration.GetValue<string>("UseExporter").ToLowerInvariant();
                    switch (exporter)
                    {
                        case "jaeger":
                            tracerBuilder
                                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("microserver"))
                                .AddAspNetCoreInstrumentation()
                                .AddJaegerExporter();
                            // https://github.com/open-telemetry/opentelemetry-dotnet/blob/21c1791e8e2bdb292ff87b044d2b92e9851dbab9/src/OpenTelemetry.Exporter.Jaeger/JaegerExporterOptions.cs
                            services.Configure<OpenTelemetry.Exporter.JaegerExporterOptions>(Configuration.GetSection("Jaeger"));
                            break;
                        case "zipkin":
                            tracerBuilder
                                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("microserver"))
                                .AddAspNetCoreInstrumentation()
                                .AddZipkinExporter();
                            // https://github.com/open-telemetry/opentelemetry-dotnet/blob/21c1791e8e2bdb292ff87b044d2b92e9851dbab9/src/OpenTelemetry.Exporter.Zipkin/ZipkinExporterOptions.cs
                            services.Configure<OpenTelemetry.Exporter.ZipkinExporterOptions>(this.Configuration.GetSection("Zipkin"));
                            break;
                        default:
                            // ConsoleExporter will show current tracer activity
                            tracerBuilder
                                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("microserver"))
                                .AddAspNetCoreInstrumentation()
                                .AddConsoleExporter();
                            services.Configure<OpenTelemetry.Instrumentation.AspNetCore.AspNetCoreInstrumentationOptions>(this.Configuration.GetSection("AspNetCoreInstrumentation"));
                            services.Configure<OpenTelemetry.Instrumentation.AspNetCore.AspNetCoreInstrumentationOptions>(options =>
                            {
                                options.Filter = (req) => req.Request?.Host != null;
                            });
                            break;
                    }
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapMagicOnionService();
                endpoints.MapGrpcService<GreeterService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
