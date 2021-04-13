using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Tuples;

namespace ObjRenderer.Shapes
{
    public abstract class Shape : ITraceable, ITransformable
    {
        public Matrix Transform { get; set; }

        protected Shape()
        {
            Transform = Matrix.Identity;
        }

        public IntersectionCollection Intersect(Ray ray)
        {
            var localRay = ray.Transform(Transform.Inverse());
            return LocalIntersect(localRay);
        }

        public Vector NormalAt(Point worldPoint, IntersectionWithUV hit = null)
        {
            var localPoint = WorldToObject(worldPoint);
            var localNormal = LocalNormalAt(localPoint, hit);

            return NormalToWorld(localNormal);
        }

        public Point WorldToObject(Point point)
        {
            return (Point)(Transform.Inverse() * point);
        }

        public Vector NormalToWorld(Vector normal)
        {
            var normalMatrix = Transform.Inverse().Transpose() * normal;

            normal = new Vector(normalMatrix[0, 0], normalMatrix[1, 0], normalMatrix[2, 0]);
            normal = normal.Normalize();

            return normal;
        }

        public abstract IntersectionCollection LocalIntersect(Ray ray);

        public abstract Vector LocalNormalAt(Point point, IntersectionWithUV hit = null);
    }
}