using CG.RayTracer.Core.Intersections;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer.Core.Interfaces
{
    public interface ITraceable
    {
        Intersection? Intersect(Ray r);
    }
}