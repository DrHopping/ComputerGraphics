using System;
using System.Numerics;

namespace CG.RayTracer.Core.Matrices
{
    public static class Matrix
    {
        public static Matrix4x4 Identity = new Matrix4x4(
        
             1, 0, 0, 0 ,
             0, 1, 0, 0 ,
             0, 0, 1, 0 ,
             0, 0, 0, 1 
        );

        public static Matrix4x4 Translation(float x, float y, float z)
        {
            return new Matrix4x4(
            
                 1, 0, 0, x ,
                 0, 1, 0, y ,
                 0, 0, 1, z ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 Scaling(float x, float y, float z)
        {
            return new Matrix4x4(
            
                 x, 0, 0, 0 ,
                 0, y, 0, 0 ,
                 0, 0, z, 0 ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 RotationX(float radians)
        {
            return new Matrix4x4(
                 1, 0, 0, 0 ,
                 0, MathF.Cos(radians), -MathF.Sin(radians), 0 ,
                 0, MathF.Sin(radians), MathF.Cos(radians), 0 ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 RotationY(float radians)
        {
            return new Matrix4x4(
                MathF.Cos(radians), 0, MathF.Sin(radians), 0 ,
                 0, 1, 0 , 0 ,
                 -MathF.Sin(radians), 0, MathF.Cos(radians), 0 ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 RotationZ(float radians)
        {
            return new Matrix4x4(
            
                 MathF.Cos(radians), -MathF.Sin(radians), 0, 0 ,
                 MathF.Sin(radians), MathF.Cos(radians), 0, 0 ,
                 0, 0, 1, 0 ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 Shearing(float xy, float xz, float yx, float yz, float zx, float zy)
        {
            return new Matrix4x4(
            
                 1, xy, xz, 0 ,
                 yx, 1, yz, 0 ,
                 zx, zy, 1, 0 ,
                 0, 0, 0, 1 
            );
        }

        public static Matrix4x4 View(Vector3 from, Vector3 to, Vector3 up)
        {
            var forward = Vector3.Normalize(to - from);
            var upNormalized = Vector3.Normalize(up);
            var left = Vector3.Cross(forward,upNormalized);
            var trueUp = Vector3.Cross(left,forward);

            var orientation = new Matrix4x4(
            
                 left.X, left.Y, left.Z, 0 ,
                 trueUp.X, trueUp.Y, trueUp.Z, 0 ,
                 -forward.X, -forward.Y, -forward.Z, 0 ,
                 0, 0, 0, 1 
            );

            return orientation * Translation(-from.X, -from.Y, -from.Z);
        }

        public static Matrix4x4 Translate(this Matrix4x4 matrix, float x, float y, float z)
        {
            return Translation(x, y, z) * matrix;
        }

        public static Matrix4x4 Scale(this Matrix4x4 matrix, float x, float y, float z)
        {
            return Scaling(x, y, z) * matrix;
        }

        public static Matrix4x4 RotateX(this Matrix4x4 matrix, float radians)
        {
            return RotationX(radians) * matrix;
        }

        public static Matrix4x4 RotateY(this Matrix4x4 matrix, float radians)
        {
            return RotationY(radians) * matrix;
        }

        public static Matrix4x4 RotateZ(this Matrix4x4 matrix, float radians)
        {
            return RotationZ(radians) * matrix;
        }

        public static Matrix4x4 Shear(this Matrix4x4 matrix, float xy, float xz, float yx, float yz, float zx, float zy)
        {
            return Shearing(xy, xz, yx, yz, zx, zy) * matrix;
        }

    }
}