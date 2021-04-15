using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Matrices;
using ObjRenderer.Shapes;

namespace ObjRenderer.Models
{
    public class Mesh : ITraceable, ITransformable
    {
        private readonly IEnumerable<Triangle> _triangles;

        public Mesh(IEnumerable<Triangle> triangles)
        {
            _triangles = triangles;
            //ResetToDefault();
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

        private void ResetToDefault()
        {
            var xs = _triangles.Select(_ => new[] { _.P1.X, _.P2.X, _.P3.X })
                .SelectMany(_ => _);
            var ys = _triangles.Select(_ => new[] { _.P1.Y, _.P2.Y, _.P3.Y })
                .SelectMany(_ => _);
            var zs = _triangles.Select(_ => new[] { _.P1.X, _.P2.X, _.P3.X })
                .SelectMany(_ => _);
            var averageX = xs.Average();
            var averageY = ys.Average();
            var averageZ = zs.Average();
            var maxX = xs.Select(Math.Abs).Max();
            var maxY = ys.Select(Math.Abs).Max();
            var maxZ = zs.Select(Math.Abs).Max();
            var maxValue = new[] { maxX, maxY, maxZ }.Max();
            var scale = 10 / maxValue;
            Transform(Matrix4x4.Identity.Translate(-averageX, -averageY, -averageZ).Scale(scale,scale,scale));
        }
    }
}