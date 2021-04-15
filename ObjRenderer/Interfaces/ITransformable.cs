using System.Numerics;
using ObjRenderer.Matrices;

namespace ObjRenderer.Interfaces
{
    public interface ITransformable
    {
        public void Transform(Matrix4x4 matrix);
    }
}