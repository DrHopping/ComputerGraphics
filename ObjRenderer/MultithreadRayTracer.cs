using System.Threading.Tasks;
using ObjRenderer.Image;
using ObjRenderer.Interfaces;
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
            int width = scene.Camera.HorizontalSize;
            int height = scene.Camera.VerticalSize;
            var image = new Canvas(width, height);

            Parallel.ForEach(scene.Objects, @object =>
            {
                Parallel.For(0, width, i =>
                {
                    Parallel.For(0, height, j =>
                    {
                        var ray = scene.Camera.RayForPixel(i, j);
                        var intersectionCollection = @object.Intersect(ray);

                        if (intersectionCollection.Length > 0)
                        {
                            image[i, j] = _illuminationStrategy.Illuminate(scene.Light, intersectionCollection.Hit);
                        }
                    });
                });
            });
            return image;
        }
    }
}