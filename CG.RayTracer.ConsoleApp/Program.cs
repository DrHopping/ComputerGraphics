using System;
using System.Threading.Tasks;
using CG.DependencyInjection;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Light;
using CommandLine;

namespace CG.RayTracer.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new DiServiceCollection();

            services.RegisterTransient<IIlluminationStrategy, FlatShading>();
            services.RegisterTransient<ICameraProvider, CameraProvider>();
            services.RegisterTransient<ILightProvider, LightProvider>();
            services.RegisterTransient<IRayProvider, RayProvider>();
            services.RegisterTransient<IRayTracer, MultiThreadRayTracer>();
            services.RegisterTransient<ISceneProvider, SceneProvider>();
            services.RegisterSingleton<IApp, App>();

            var container = services.GenerateContainer();
            var app = container.GetService<IApp>();

            await Parser.Default.ParseArguments<CommandLineArgs>(args)
                .WithParsedAsync(async arguments =>
                {
                    try
                    {
                        await app.Run(arguments.FileName, arguments.Output);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
        }
    }
}
