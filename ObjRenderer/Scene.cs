using System;
using System.Collections.Generic;
using System.Linq;
using ObjRenderer.Image;
using ObjRenderer.Intersections;
using ObjRenderer.Light;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Shapes;
using ObjRenderer.Tuples;

namespace ObjRenderer
{
    public class Scene
    {
        public List<Shape> Objects { get; set; }
        public PointLight Light { get; set; }
        public Camera Camera { get; set; }

        public Scene()
        {
            Objects = new List<Shape>();
            Light = new PointLight(new Point(5,5,7));
            Camera = new Camera(400, 400, MathF.PI / 3);
        }
    }
}