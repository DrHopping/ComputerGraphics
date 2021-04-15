using CG.RayTracer.Core.Image;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer.Core.Interfaces
{
    public interface IRayTracer
    {
        Canvas Render(Scene scene);
    }
}