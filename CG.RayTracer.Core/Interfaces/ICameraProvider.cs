using CG.RayTracer.Core.Models;

namespace CG.RayTracer.Core.Interfaces
{
    public interface ICameraProvider
    {
        Camera GetCamera();
    }
}