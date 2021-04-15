using System.Numerics;
using ObjRenderer.Intersections;
using ObjRenderer.Models;

namespace ObjRenderer.Interfaces
{
    public interface ITraceable
    {
        Intersection? Intersect(Ray r);
    }
}