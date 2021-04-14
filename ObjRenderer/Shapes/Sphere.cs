using System;
using ObjRenderer.Intersections;
using ObjRenderer.Models;
using ObjRenderer.Tuples;

namespace ObjRenderer.Shapes
{
    public class Sphere : Shape
    {
        public override IntersectionCollection LocalIntersect(Ray ray)
        {
            var sphereToRay = ray.Origin - Point.Origin;

            var a = ray.Direction * ray.Direction;
            var b = 2 * ray.Direction * sphereToRay;
            var c = sphereToRay * sphereToRay - 1;

            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return new IntersectionCollection();
            }

            var t1 = (-b - MathF.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b + MathF.Sqrt(discriminant)) / (2 * a);

            var i1 = new Intersection(t1, this, ray.Position(t1));
            var i2 = new Intersection(t2, this, ray.Position(t2));

            return new IntersectionCollection(i1, i2);
        }

        public override Vector LocalNormalAt(Point point, IntersectionWithUV hit = null)
        {
            var localNormal = point - Point.Origin;

            return localNormal;
        }
    }
}