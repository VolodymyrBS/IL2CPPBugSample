using Injecter.Hosting.Unity;
using Injecter.Unity;
using MainThreadDispatcher;
using MainThreadDispatcher.Unity;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Unity3D;
using System;
using UnityEngine;

namespace IL2CPPBugSample
{
    [DefaultExecutionOrder(-999)]
    public class SceneStarter : InjectStarter
    {
        private IHost _host;

        protected override IServiceProvider CreateServiceProvider()
        {
            _host = new HostBuilder()
                .UseUnityLifetime()
                .ConfigureServices(ConfigureServices)
                .UseSerilog((_, __, config) => config.WriteTo.Unity3D())
                .Build();

            return _host.Services;
        }

        protected override void Awake()
        {
            base.Awake();

            LoadEagerServices();

            _host.Start();
        }

        private void OnApplicationQuit() => _host?.Dispose();

        private void LoadEagerServices() => _host.Services.GetRequiredService<IMainThreadDispatcher>();

        private static void ConfigureServices(HostBuilderContext _, IServiceCollection services)
        {
            services.AddSceneInjector(
                options => options.UseCaching = true,
                options =>
                {
                    options.DontDestroyOnLoad = true;
                    options.InjectionBehavior = SceneInjectorOptions.Behavior.Factory;
                });

            services.AddSingleton<IMainThreadDispatcher>(sp => FindObjectOfType<UnityMainThreadDispatcher>());

            services.AddMediatR(typeof(SceneStarter).Assembly);
        }
    }
}
