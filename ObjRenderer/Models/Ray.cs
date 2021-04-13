using ObjRenderer.Matrices;
using ObjRenderer.Tuples;

namespace ObjRenderer.Models
{
    public class Ray
    {
        public Point Origin { get; }
        public Vector Direction { get; }

        public Ray(Point origin, Vector direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Point Position(float t)
        {
            return Origin + Direction * t;
        }

        public Ray Transform(Matrix transform)
        {
            var origin = (Point)(transform * Origin);
            var direction = (Vector)(transform * Direction);

            return new Ray(origin, direction);
        }
    }
}