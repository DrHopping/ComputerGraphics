using System;
using ObjRenderer.Matrices;

namespace ObjRenderer.Tuples
{
    public class Vector : Tuple
    {
        public static Vector Zero => new Vector(0, 0, 0);

        public float Length => MathF.Sqrt(X * X + Y * Y + Z * Z);

        public Vector(float x, float y, float z) : base(x, y, z, 0) { }

        public Vector Normalize()
        {
            var length = Length;

            return new Vector(X / length, Y / length, Z / length);
        }

        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y, Z + v.Z);
        }

        public Vector Substract(Vector v)
        {
            return new Vector(X - v.X, Y - v.Y, Z - v.Z);
        }

        public Vector Negate()
        {
            return new Vector(-X, -Y, -Z);
        }

        public Vector Multiply(float escalar)
        {
            return new Vector(X * escalar, Y * escalar, Z * escalar);
        }

        public Vector Divide(float escalar)
        {
            return new Vector(X / escalar, Y / escalar, Z / escalar);
        }

        public float Dot(Vector v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector Cross(Vector v)
        {
            return new Vector(Y * v.Z - Z * v.Y,
                              Z * v.X - X * v.Z,
                              X * v.Y - Y * v.X);
        }

        public Vector Reflect(Vector normal)
        {
            return Substract(normal * 2 * Dot(normal));
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static explicit operator Vector(Matrix matrix)
        {
            if (matrix.Rows != 4 || matrix.Columns != 1 ||
                matrix[3, 0] != 0)
            {
                throw new InvalidOperationException();
            }

            return new Vector(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
        }


        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Substract(v2);
        }

        public static Vector operator -(Vector v)
        {
            return v.Negate();
        }

        public static Vector operator *(Vector v, float escalar)
        {
            return v.Multiply(escalar);
        }

        public static Vector operator *(float escalar, Vector v)
        {
            return v.Multiply(escalar);
        }

        public static Vector operator /(Vector v, float escalar)
        {
            return v.Divide(escalar);
        }

        public static float operator *(Vector v1, Vector v2)
        {
            return v1.Dot(v2);
        }
    }
}