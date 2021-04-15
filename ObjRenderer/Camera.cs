using System;
using System.Numerics;
using ObjRenderer.Interfaces;
using ObjRenderer.Matrices;
using ObjRenderer.Models;

namespace ObjRenderer
{
    public class Camera 
    {
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



        private static readonly float _angle = 0;
        private readonly float _cos = MathF.Cos(_angle);
        private readonly float _sin = MathF.Sin(_angle);

        public Camera(int horizontalSize, int verticalSize, float fieldOfView)
        {
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
        public Ray GetRay(int x, int y)
        {
            var scale = MathF.Tan(Angle * MathF.PI / 2 / 180);
            var aspectRatio = Width / Height;
            var px = (2 * (x + .5f) / Width - 1.0f) * scale * aspectRatio;
            var py = (1 - 2 * (y + .5f) / Height) * scale;
            var direction = Direction + new Vector3(px, py, 0) - Origin;
            var translationMatrix = Matrix4x4.Transpose(new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 400,
                0, 0, 1, -1000,
                0, 0, 0, 1));
            var rotationMatrix = Matrix4x4.Transpose(new Matrix4x4(
                1, 0, 0, 0,
                0, _cos, -_sin, 0,
                0, _sin, _cos, 0,
                0, 0, 0, 1));
            var transformedOrigin = Vector3.Transform(Origin, translationMatrix);
            var ray = new Ray(transformedOrigin, Vector3.Normalize(Vector3.Transform(direction, rotationMatrix)));
            return ray;
        }

        public Ray RayForPixel(int px, int py)
        {
            // The offset from the edge of the canvas to the pixel's center
            var xOffset = (px + 0.5f) * PixelSize;
            var yOffset = (py + 0.5f) * PixelSize;

            // The unstranformed coordinates of the pixel in world space.
            // (Remember that the camera looks toward -z, so +x is to the *left*.)
            var worldX = HalfWidth - xOffset;
            var worldY = HalfHeight - yOffset;

            // Using the camera matrix, transform the canvas point and the origin,
            // and then compute the ray's director vector.
            // (Remember that the canvas is at z = -1)
            Matrix4x4.Invert(Transform, out var inverseTransform);
            var pixel = Vector3.Transform(new Vector3(worldX, worldY, -1), inverseTransform);
            var origin = Vector3.Transform(new Vector3(0, 0, 0), inverseTransform);
            var direction = Vector3.Normalize(pixel - origin);

            return new Ray(origin, direction);
        }


    }
}