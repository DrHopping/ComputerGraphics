using System.Numerics;
using CG.RayTracer.Core.Image;
using CG.RayTracer.Core.Intersections;
using CG.RayTracer.Core.Light;
using ObjRenderer.Light;

namespace CG.RayTracer
{
    public class FlatShading : IIlluminationStrategy
    {
        public Color Illuminate(PointLight light, Intersection intersection)
        {
            var lightDir = Vector3.Normalize(light.Position - intersection.P);
            var color = Vector3.Dot(intersection.Normal, lightDir);
            color += .2f;
            return new Color(color, color, color);
        }
    }
}