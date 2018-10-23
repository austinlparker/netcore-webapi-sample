using System;
using System.Reflection;
using Jaeger;
using Jaeger.Metrics;
using Jaeger.Samplers;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Contrib.NetCore.CoreFx;
using OpenTracing.Util;
using LightStep;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LightStepServiceCollectionExtensions
    {
        private static readonly string _lightStepProjectKey = Environment.GetEnvironmentVariable("LS_KEY");
        public static IServiceCollection AddLightStep(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            
            services.AddSingleton<ITracer>(serviceProvider => 
            {
                string serviceName = Assembly.GetEntryAssembly().GetName().Name;
                ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                
                var options = new LightStep.Options(_lightStepProjectKey, new SatelliteOptions("collector.lightstep.com"));

                ITracer tracer = new LightStep.Tracer(options);

                GlobalTracer.Register(tracer);

                return tracer;
            });

            return services;
        }
    }
}