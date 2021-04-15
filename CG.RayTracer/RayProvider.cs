using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer
{
    public class RayProvider : IRayProvider
    {
        public Ray RayForPixel(int px, int py, Camera camera)
        {
            var xOffset = (px + 0.5f) * camera.PixelSize;
            var yOffset = (py + 0.5f) * camera.PixelSize;

            var worldX = camera.HalfWidth - xOffset;
            var worldY = camera.HalfHeight - yOffset;

            Matrix4x4.Invert(camera.Transform, out var inverseTransform);
            var pixel = Vector3.Transform(new Vector3(worldX, worldY, -1), inverseTransform);
            var origin = Vector3.Transform(new Vector3(0, 0, 0), inverseTransform);
            var direction = Vector3.Normalize(pixel - origin);

            return new Ray(origin, direction);
        }
    }
}