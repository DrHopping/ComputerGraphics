using System.Numerics;

namespace CG.RayTracer.Core.Interfaces
{
    public interface ITransformable
    {
        public void Transform(Matrix4x4 matrix);
    }
}