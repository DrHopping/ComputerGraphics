using System.Collections.Generic;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer
{
    public class SceneProvider : ISceneProvider
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly ILightProvider _lightProvider;

        public SceneProvider(ICameraProvider cameraProvider, ILightProvider lightProvider)
        {
            _cameraProvider = cameraProvider;
            _lightProvider = lightProvider;
        }

        public Scene GetScene()
        {
            return new Scene()
            {
                Camera = _cameraProvider.GetCamera(),
                Light = _lightProvider.GetLight(),
                Objects = new List<ITraceable>()
            };
        }
    }
}