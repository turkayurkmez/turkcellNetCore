using LifeCycleOfDI.Models;

namespace LifeCycleOfDI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInjectionTools(this IServiceCollection services)
        {

            services.AddSingleton<ISingletonGuid, SingletonGuid>();
            services.AddScoped<IScopedGuid, ScopedGuid>();
            services.AddTransient<ITransientGuid, TransientGuid>();
            services.AddTransient<GuidService>();

            return services;
        }
    }
}
