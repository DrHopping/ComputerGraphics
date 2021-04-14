using System;
using ObjRenderer.Interfaces;
using ObjRenderer.Matrices;
using ObjRenderer.Models;
using ObjRenderer.Tuples;

namespace ObjRenderer
{
    public class Camera : ITransformable
    {
        public Matrix Transform { get; set; }
        public int HorizontalSize { get; }
        public int VerticalSize { get; }
        public float FieldOfView { get; }
        public float PixelSize { get; }
        public float HalfWidth { get; }
        public float HalfHeight { get; set; }

        public Camera(int horizontalSize, int verticalSize, float fieldOfView)
        {
            HorizontalSize = horizontalSize;
            VerticalSize = verticalSize;
            FieldOfView = fieldOfView;

            Transform = Matrix.Identity;

            var halfView = MathF.Tan(fieldOfView / 2);
            var aspect = (float) horizontalSize / verticalSize;

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
            var inverseTransform = Transform.Inverse();
            var pixel = (Point) (inverseTransform * new Point(worldX, worldY, -1));
            var origin = (Point) (inverseTransform * new Point(0, 0, 0));
            var direction = (pixel - origin).Normalize();

            return new Ray(origin, direction);
        }
    }
}