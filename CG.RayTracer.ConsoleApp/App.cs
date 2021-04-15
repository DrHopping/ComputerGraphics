using System;
using CG.RayTracer.Core.Interfaces;
using System.IO;
using System.Threading.Tasks;
using CG.RayTracer.Core.Extensions;
using CG.RayTracer.Core.Matrices;


namespace CG.RayTracer.ConsoleApp
{
    interface IApp
    {
        Task Run(string inputFile, string outputFile);
    }
    public class App : IApp
    {
        private readonly IRayTracer _rayTracer;
        private readonly ISceneProvider _sceneProvider;

        public App(IRayTracer rayTracer, ISceneProvider sceneProvider)
        {
            _rayTracer = rayTracer;
            _sceneProvider = sceneProvider;
        }
        public async Task Run(string inputFile, string outputFile)
        {
            var @object = new ObjParser(await File.ReadAllTextAsync(inputFile)).ToGroup().ToMesh();
            @object.Transform(Matrix.RotationX(MathF.PI / 2).Scale(5, 5, 5));

            var scene = _sceneProvider.GetScene();
            scene.Objects.Add(@object);

            var image = _rayTracer.Render(scene);
            var sr = new StreamWriter($"{Path.GetFileNameWithoutExtension(outputFile)}.ppm");
            await image.ToPpmAsync(sr.BaseStream);
        }
    }
}