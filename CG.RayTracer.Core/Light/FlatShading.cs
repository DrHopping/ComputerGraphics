using System.Numerics;
using CG.RayTracer.Core.Image;
using CG.RayTracer.Core.Intersections;
using ObjRenderer.Light;

namespace CG.RayTracer.Core.Light
{
    public class FlatShading : IIlluminationStrategy
    {
        public Color Illuminate(PointLight light, Intersection intersection)
        {
            var lightDir = Vector3.Normalize(light.Position - intersection.P);
            var color = Vector3.Dot(intersection.Normal, lightDir);
            color += .2f;
            color = 1;
            return new Color(color, color, color);
        }
    }
}