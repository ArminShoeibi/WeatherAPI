using System;
using System.Threading;

using Microsoft.Extensions.DependencyInjection;

namespace WeatherAPI.Services
{
    /// <summary>
    /// Thanks to https://github.com/SinjulMSBH
    /// </summary>
    public static class ServiceLocatorProvider
    {
        private static readonly Lazy<IServiceProvider> _serviceProviderBuilder =
            new(GetServiceProvider, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IServiceProvider ServiceProvider { get; } = _serviceProviderBuilder.Value;

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            return services.BuildServiceProvider(false);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<WeatherService>();
        }
    }

    public static class ServiceLocator
    {
        public static TService GetService<TService>() =>
            ServiceLocatorProvider.ServiceProvider.GetService<TService>();

        public static TService GetRequiredService<TService>() =>
            ServiceLocatorProvider.ServiceProvider.GetRequiredService<TService>();
        public static object GetService(Type serviceType) =>
            ServiceLocatorProvider.ServiceProvider.GetService(serviceType);

        public static object GetRequiredService(Type serviceType) =>

            ServiceLocatorProvider.ServiceProvider.GetRequiredService(serviceType);


        public static void RunScopedService<S>(Action<S> callback)
        {
            using IServiceScope serviceScope =
                ServiceLocatorProvider.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            S context = serviceScope.ServiceProvider.GetRequiredService<S>();

            callback(context);

            if (context is IDisposable disposable)
                disposable.Dispose();
        }

        public static void RunScopedService<T, S>(Action<S, T> callback)
        {
            using IServiceScope serviceScope =
                ServiceLocatorProvider.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            S context = serviceScope.ServiceProvider.GetRequiredService<S>();

            callback(context, serviceScope.ServiceProvider.GetRequiredService<T>());

            if (context is IDisposable disposable)
                disposable.Dispose();
        }

        public static T RunScopedService<T, S>(Func<S, T> callback)
        {
            using IServiceScope serviceScope =
                ServiceLocatorProvider.ServiceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            S context = serviceScope.ServiceProvider.GetRequiredService<S>();

            return callback(context);
        }
    }
}



