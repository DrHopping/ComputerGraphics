using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.KDTree;
using ObjRenderer.Matrices;
using ObjRenderer.Shapes;

namespace ObjRenderer.Models
{
    public class Mesh : ITraceable, ITransformable
    {
        private IEnumerable<Triangle> _triangles;
        private KdTree _tree;

        public Mesh(IEnumerable<Triangle> triangles)
        {
            _triangles = triangles;
            _tree = new KdTree(_triangles.ToArray());
        }

        public void Transform(Matrix4x4 matrix4X4)
        {
            foreach (var triangle in _triangles)
            {
                triangle.Transform(matrix4X4);
            }
        }

        public Intersection? Intersect(Ray r)
        {
            //return _tree.Traverse(r);
            Intersection? hitResult = null;
            foreach (var triangle in _triangles)
            {
                var hit = triangle.Intersect(r);
                if (!hit.HasValue) continue;
                if (!hitResult.HasValue)
                {
                    hitResult = hit;
                }
                else
                {
                    if (hitResult.Value.T <
                        hit.Value.T)
                    {
                        hitResult = hit;
                    }
                }
            }

            return hitResult;
        }
    }
}