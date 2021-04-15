using System;
using System.Drawing;
using System.Numerics;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Models;

namespace ObjRenderer.Shapes
{
    public class Sphere : ITraceable, ITransformable
    {
        public float Radius { get; set; }
        public Vector3 Center { get; set; }

        public Sphere(float radius, Vector3 center)
        {
            Radius = radius;
            Center = center;
        }

        public Intersection? Intersect(Ray r)
        {
            var sphereToRay = r.Origin - Center;

            var a = Vector3.Dot(r.Direction, r.Direction);
            var b = 2 * Vector3.Dot(r.Direction, sphereToRay);
            var c = Vector3.Dot(sphereToRay, sphereToRay) - Radius * Radius;

            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return null;
            }

            var t1 = (-b - MathF.Sqrt(discriminant)) / (2 * a);
            var t2 = (-b + MathF.Sqrt(discriminant)) / (2 * a);
            var point = r.Position(MathF.Min(t1, t2));


            return new Intersection()
            {
                P = point,
                Normal = point - Center,
                T = MathF.Min(t1, t2)
            };
        }

        public void Transform(Matrix4x4 matrix)
        {
            throw new NotImplementedException();
        }
    }
}