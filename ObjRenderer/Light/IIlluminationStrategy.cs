using ObjRenderer.Image;
using ObjRenderer.Intersections;

namespace ObjRenderer.Light
{
    public interface IIlluminationStrategy
    {
        Color Illuminate(PointLight light, Intersection intersection);
    }
}