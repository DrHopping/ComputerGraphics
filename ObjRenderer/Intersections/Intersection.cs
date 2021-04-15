using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ObjRenderer.Extensions;
using ObjRenderer.Models;
using ObjRenderer.Shapes;

namespace ObjRenderer.Intersections
{
    public struct Intersection
    {
        public float T { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 P { get; set;}

    }
}