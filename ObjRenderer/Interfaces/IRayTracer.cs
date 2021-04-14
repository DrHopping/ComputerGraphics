using ObjRenderer.Image;

namespace ObjRenderer.Interfaces
{
    public interface IRayTracer
    {
        Canvas Render(Scene scene);
    }
}