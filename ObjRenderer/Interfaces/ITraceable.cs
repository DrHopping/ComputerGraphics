using ObjRenderer.Intersections;
using ObjRenderer.Models;

namespace ObjRenderer.Interfaces
{
    public interface ITraceable
    {
        IntersectionCollection Intersect(Ray r);
    }
}