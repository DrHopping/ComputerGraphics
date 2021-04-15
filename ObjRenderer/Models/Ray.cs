using System.Numerics;
using ObjRenderer.Matrices;

namespace ObjRenderer.Models
{
    public class Ray
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vector3 Position(float t)
        {
            return Origin + Direction * t;
        }
    }
}