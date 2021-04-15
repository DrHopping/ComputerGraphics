using ObjRenderer.Light;

namespace CG.RayTracer.Core.Interfaces
{
    public interface ILightProvider
    {
        PointLight GetLight();
    }
}