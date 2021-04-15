using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ObjRenderer.Image;
using ObjRenderer.Interfaces;
using ObjRenderer.Intersections;
using ObjRenderer.Light;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Shapes;

namespace ObjRenderer
{
    public class Scene
    {
        public List<ITraceable> Objects { get; set; }
        public PointLight Light { get; set; }
        public Camera Camera { get; set; }

        public Scene()
        {
            Objects = new List<ITraceable>();
            Light = new PointLight(new Vector3(5,5,7));
            Camera = new Camera(500, 500, MathF.PI / 3)
            {
                Width = 500,
                Height = 500,
                Angle = 60,
                Direction = Vector3.UnitZ,
                Origin = Vector3.Zero
            };
        }
    }
}