using System;
using System.Collections.Generic;
using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using ObjRenderer.Light;

namespace CG.RayTracer.Core.Models
{
    public class Scene
    {
        public List<ITraceable> Objects { get; set; }
        public PointLight Light { get; set; }
        public Camera Camera { get; set; }

    }
}