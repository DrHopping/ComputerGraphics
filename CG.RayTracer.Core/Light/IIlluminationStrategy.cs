using CG.RayTracer.Core.Image;
using CG.RayTracer.Core.Intersections;
using ObjRenderer.Light;

namespace CG.RayTracer.Core.Light
{
    public interface IIlluminationStrategy
    {
        Color Illuminate(PointLight light, Intersection intersection);
    }
}