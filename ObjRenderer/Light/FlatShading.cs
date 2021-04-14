using ObjRenderer.Image;
using ObjRenderer.Intersections;

namespace ObjRenderer.Light
{
    public class FlatShading : IIlluminationStrategy
    {
        public Color Illuminate(PointLight light, Intersection intersection)
        {
            var lightDir = (light.Position - intersection.P).Normalize();
            var color = intersection.Object.NormalAt(intersection.P) * lightDir;
            color += .2f;
            color = 1;
            return new Color(color, color, color);
        }
    }
}