using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using ObjRenderer.Light;

namespace CG.RayTracer
{
    public class LightProvider : ILightProvider
    {
        public PointLight GetLight()
        {
            return new PointLight(new Vector3(0, 0, 100));
        }
    }
}