using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ObjRenderer.Intersections;
using ObjRenderer.Models;
using ObjRenderer.Tuples;

namespace ObjRenderer.Shapes
{
    public class Group : Shape, IEnumerable<Shape>
    {
        private List<Shape> _shapes;

        public Group(IEnumerable<Shape> shapes) : this()
        {
            AddChildren(shapes);
        }

        public Group()
        {
            _shapes = new List<Shape>();
        }

        public void AddChild(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void AddChildren(IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                AddChild(shape);
            }
        }

        public override IntersectionCollection LocalIntersect(Ray ray)
        {
            var intersects = _shapes.SelectMany(shape => shape.Intersect(ray)).ToArray();

            return new IntersectionCollection(intersects);
        }

        public override Vector LocalNormalAt(Point point, IntersectionWithUV hit = null)
        {
            throw new NotImplementedException();
        }

        public Shape this[int i] => _shapes[i];

        public IEnumerator<Shape> GetEnumerator()
        {
            return _shapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}