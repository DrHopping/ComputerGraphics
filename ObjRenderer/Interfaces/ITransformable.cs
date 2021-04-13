using ObjRenderer.Matrices;

namespace ObjRenderer.Interfaces
{
    public interface ITransformable
    {
        Matrix Transform { get; set; }
    }
}