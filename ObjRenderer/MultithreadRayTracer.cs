using System.Threading.Tasks;
using ObjRenderer.Image;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Light;

namespace ObjRenderer
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