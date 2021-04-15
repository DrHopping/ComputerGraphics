using System.Numerics;
using CG.RayTracer.Core.Intersections;
using CG.RayTracer.Core.Models;
using CG.RayTracer.Core.Shapes;

namespace CG.RayTracer.Core.KDTree
{
    public class KdTree
    {
        public KdTreeNode HeadNode { get; set; }

        public KdTree(Triangle[] triangles)
        {
            var minX = float.MaxValue;
            var minY = float.MaxValue;
            var minZ = float.MaxValue;

            var maxX = float.MinValue;
            var maxY = float.MinValue;
            var maxZ = float.MinValue;

            foreach (var triangle in triangles)
            {
                if (minX > triangle.BoxMin.X) minX = triangle.BoxMin.X;
                if (minY > triangle.BoxMin.Y) minY = triangle.BoxMin.Y;
                if (minZ > triangle.BoxMin.Z) minZ = triangle.BoxMin.Z;

                if (maxX < triangle.BoxMax.X) maxX = triangle.BoxMax.X;
                if (maxY < triangle.BoxMax.Y) maxY = triangle.BoxMax.Y;
                if (maxZ < triangle.BoxMax.Z) maxZ = triangle.BoxMax.Z;
            }


            var boxMax = new Vector3(maxX, maxY, maxZ);
            var boxMin = new Vector3(minX, minY, minZ);

            HeadNode = new KdTreeNode(triangles, boxMin, boxMax, 1);
            HeadNode.SplitNode();
        }

        public Intersection? Traverse(in Ray ray)
        {
            return HeadNode.Traverse(ray);
        }
    }
}