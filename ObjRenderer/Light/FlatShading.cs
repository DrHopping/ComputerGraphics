using System.Numerics;
using ObjRenderer.Image;
using ObjRenderer.Intersections;

namespace ObjRenderer.Light
{
    public class FlatShading : IIlluminationStrategy
    {
        public Color Illuminate(PointLight light, Intersection intersection)
        {
            var lightDir = Vector3.Normalize(light.Position - intersection.P);
            var color = Vector3.Dot(intersection.Normal, lightDir);
            color += .25f;
            return new Color(color, color, color);
        }
    }
}