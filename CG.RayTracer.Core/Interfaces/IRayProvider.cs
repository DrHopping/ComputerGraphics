using CG.RayTracer.Core.Models;

namespace CG.RayTracer.Core.Interfaces
{
    public interface IRayProvider
    {
        Ray RayForPixel(int px, int py, Camera camera);
    }
}