using System.Numerics;

namespace CG.RayTracer.Core.Intersections
{
    public struct Intersection
    {
        public float T { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 P { get; set;}

    }
}