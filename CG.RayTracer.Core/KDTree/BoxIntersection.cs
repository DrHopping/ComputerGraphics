namespace CG.RayTracer.Core.KDTree
{
    public struct RayBoxIntersection
    {
        public bool Intersected { get; set; }
        public float TMin { get; set; }
        public float TMax { get; set; }

        public RayBoxIntersection(bool intersected, float min, float max)
        {
            Intersected = intersected;
            TMin = min;
            TMax = max;
        }
    }
}