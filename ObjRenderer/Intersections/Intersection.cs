using System.Collections.Generic;
using System.Linq;
using ObjRenderer.Extensions;
using ObjRenderer.Models;
using ObjRenderer.Shapes;
using ObjRenderer.Tuples;

namespace ObjRenderer.Intersections
{
    public class Intersection
    {
        public float T { get; }
        public Shape Object { get; }
        public Point P { get; }

        public Intersection(float t, Shape @object, Point p)
        {
            T = t;
            Object = @object;
            P = p;
        }


        protected virtual Vector NormalAt(Point point)
        {
            return Object.NormalAt(point);
        }
    }
}