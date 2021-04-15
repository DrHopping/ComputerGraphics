using System;
using System.Numerics;
using CG.RayTracer.Core.Interfaces;
using CG.RayTracer.Core.Matrices;

namespace CG.RayTracer.Core.Models
{
    public class Camera 
    {
        private readonly IRayProvider _rayProvider;
        public float Angle { get; set; }
        public int Width  { get; set; }
        public int Height { get; set; }
        public Vector3 Direction { get; set; }
        public Vector3 Origin { get; set; }
        public Matrix4x4 Transform { get; set; }
        public float PixelSize { get; }
        public float HalfWidth { get; }
        public float HalfHeight { get; set; }
        public float FieldOfView { get; }

        public Camera(int horizontalSize, int verticalSize, float fieldOfView, IRayProvider _rayProvider)
        {
            this._rayProvider = _rayProvider;
            Width = horizontalSize;
            Height = verticalSize;
            FieldOfView = fieldOfView;

            Transform = Matrix.Identity;

            var halfView = MathF.Tan(fieldOfView / 2);
            var aspect = (float)horizontalSize / verticalSize;

            if (aspect >= 1)
            {
                HalfWidth = halfView;
                HalfHeight = halfView / aspect;
            }
            else
            {
                HalfWidth = halfView * aspect;
                HalfHeight = halfView;
            }

            PixelSize = HalfWidth * 2 / horizontalSize;
        }

        public Ray RayForPixel(int px, int py)
        {
            return _rayProvider.RayForPixel(px, py, this);
        }


    }
}