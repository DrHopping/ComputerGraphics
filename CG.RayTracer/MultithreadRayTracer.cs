using System.Threading.Tasks;
using CG.RayTracer.Core.Image;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Intersections;
using CG.RayTracer.Core.Light;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer
{
    public class MultiThreadRayTracer : IRayTracer
    {
        private readonly IIlluminationStrategy _illuminationStrategy;

        public MultiThreadRayTracer(IIlluminationStrategy illuminationStrategy)
        {
            _illuminationStrategy = illuminationStrategy;
        }

        public Canvas Render(Scene scene)
        {
            int width = scene.Camera.Width;
            int height = scene.Camera.Height;
            var image = new Canvas(width, height);

            Parallel.ForEach(scene.Objects, @object =>
            {
                Parallel.For(0, width, i =>
                {
                    Parallel.For(0, height, j =>
                    {
                        var ray = scene.Camera.RayForPixel(i, j);
                        var intersection = @object.Intersect(ray);

                        if (intersection != null)
                        {
                            image[i, j] = _illuminationStrategy.Illuminate(scene.Light, (Intersection) intersection);
                        }
                    });
                });
            });
            return image;
        }
    }
}