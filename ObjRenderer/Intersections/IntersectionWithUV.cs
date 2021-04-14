using ObjRenderer.Shapes;
using ObjRenderer.Tuples;

namespace ObjRenderer.Intersections
{
    public class IntersectionWithUV : Intersection
    {
        public float U { get; }
        public float V { get; }

        public IntersectionWithUV(float t, Shape @object, float u, float v, Point p) : base(t, @object, p)
        {
            U = u;
            V = v;
        }

        protected override Vector NormalAt(Point point)
        {
            return Object.NormalAt(point, this);
        }
    }
}