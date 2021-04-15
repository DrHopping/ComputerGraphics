using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Intersections;
using CG.RayTracer.Core.Models;

namespace CG.RayTracer.Core.Shapes
{
    public class SmoothTriangle : ITraceable, ITransformable
    {
        public Vector3 P1 { get; private set; }
        public Vector3 P2 { get; private set; }
        public Vector3 P3 { get; private set; }
        public Vector3 N1 { get; }
        public Vector3 N2 { get; }
        public Vector3 N3 { get; }

        public SmoothTriangle(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 n1, Vector3 n2, Vector3 n3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            N1 = n1;
            N2 = n2;
            N3 = n3;
        }

        /*public Vector NormalAt(Point point, IntersectionWithUV hit = null)
        {
            if (hit != null)
            {
                return N2 * hit.U +
                       N3 * hit.V +
                       N1 * (1 - hit.U - hit.V);
            }

            return Normal;
        }*/

        public void Transform(Matrix4x4 matrix)
        {
            P1 = Vector3.Transform(P1, matrix);
            P2 = Vector3.Transform(P2, matrix);
            P3 = Vector3.Transform(P3, matrix);
        }

        public Intersection? Intersect(Ray r)
        {
            var e1 = P2 - P1;
            var e2 = P3 - P1;
            var pvec = Vector3.Cross(r.Direction, e2);
            var det = Vector3.Dot(e1, pvec);
            if (det < 1e-8 && det > -1e-8)
            {
                return null;
            }

            var invDet = 1 / det;
            var tvec = r.Origin - P1;
            var u = Vector3.Dot(tvec, pvec) * invDet;
            if (u < 0 || u > 1)
            {
                return null;
            }

            var qvec = Vector3.Cross(tvec, e1);
            var v = Vector3.Dot(r.Direction, qvec) * invDet;
            if (v < 0 || u + v > 1)
            {
                return null;
            }

            var f = Vector3.Dot(e2, qvec) * invDet;

            return new Intersection()
            {
                P = r.Position(f),
                Normal = Vector3.Cross(e2, e1),
                T = f
            };
        }
    }
}