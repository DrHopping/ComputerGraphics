using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Models;

namespace ObjRenderer.Shapes
{
    public class Group : IEnumerable<ITraceable>
    {
        public List<ITraceable> Shapes { get; }

        public Group(IEnumerable<ITraceable> shapes) : this()
        {
            AddChildren(shapes);
        }

        public Group()
        {
            Shapes = new List<ITraceable>();
        }

        public void AddChild(ITraceable shape)
        {
            Shapes.Add(shape);
        }

        public void AddChildren(IEnumerable<ITraceable> shapes)
        {
            foreach (var shape in shapes)
            {
                AddChild(shape);
            }
        }

        public ITraceable this[int i] => Shapes[i];

        public IEnumerator<ITraceable> GetEnumerator()
        {
            return Shapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Mesh ToMesh()
        {
            return new Mesh(Shapes.Select(s => (Triangle)s));
        }
    }
}