using System.Numerics;

namespace ObjRenderer.Light
{
    public class PointLight
    {
        public Vector3 Position { get; }
        public PointLight(Vector3 position)
        {
            Position = position;
        }
    }
}