using System;
using ObjRenderer.Extensions;
using ObjRenderer.Matrices;

namespace ObjRenderer.Tuples
{
    public abstract class Tuple
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float W { get; }

        public Tuple(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static implicit operator Matrix(Tuple tuple)
        {
            var matrix = new Matrix(new float[,]
            {
                { tuple.X},
                { tuple.Y },
                { tuple.Z },
                { tuple.W }
            });

            return matrix;
        }

        public override bool Equals(object obj)
        {
            if (obj is Tuple tuple)
            {
                return tuple.X.EqualsEpsilon(X) &&
                       tuple.Y.EqualsEpsilon(Y) &&
                       tuple.Z.EqualsEpsilon(Z) &&
                       tuple.W.EqualsEpsilon(W);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, W);
        }

        public static bool operator ==(Tuple t1, Tuple t2)
        {
            return t1.Equals(t2);
        }
        public static bool operator !=(Tuple t1, Tuple t2)
        {
            return !t1.Equals(t2);
        }
    }
}