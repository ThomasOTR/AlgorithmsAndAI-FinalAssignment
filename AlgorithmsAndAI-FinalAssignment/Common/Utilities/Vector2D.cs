using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndAI_FinalAssignment.Common.Utilities
{
    public class Vector2D
    {
        public double x, y;
        public Vector2D() : this(0, 0) { }
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2D Negative()
        {
            return new Vector2D(-x,-y);
        }
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public double LengthSquared()
        {
            return x * x + y * y;
        }
        public bool WithinRange(Vector2D v, double range)
        {
            return Distance(v) < range;
        }
        public Vector2D Normalize()
        {
            double length = Length();
            if (length > 0)
            {
                x /= length;
                y /= length;
            }
            return this;
        }
        public Vector2D Perp()
        {
            return new Vector2D(-y, x);
        }
        public double Distance(Vector2D other)
        {
            return new Vector2D(x - other.x, y - other.y).Length();
        }
        /// <summary>
        /// A method to reduce the speed of the force
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public Vector2D Truncate(double max)
        {
            if (Length() > max)
            {
                Normalize();
                Multiply(max);
            }
            return this;
        }
        public Vector2D Clone()
        {
            return new Vector2D(x, y);
        }
        public Vector2D Add(Vector2D v1)
        {
            x += v1.x;
            y += v1.y;
            return this;
        }
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            Vector2D v = new Vector2D
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
            return v;
        }
        public Vector2D Subtract(Vector2D v1)
        {
            x -= v1.x;
            y -= v1.y;
            return this;
        }
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            Vector2D v = new Vector2D
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
            return v;
        }
        public Vector2D Multiply(double multiplier)
        {
            x *= multiplier;
            y *= multiplier;
            return this;

        }
        public static Vector2D operator *(Vector2D v1, double multiplier)
        {
            Vector2D v = new Vector2D
            {
                x = v1.x * multiplier,
                y = v1.y + multiplier,
            };
            return v;
        }
        public Vector2D Divide(double divider)
        {
            x /= divider;
            y /= divider;
            return this;
        }
        public static Vector2D operator /(Vector2D v1, double divider)
        {
            Vector2D v = new Vector2D
            {
                x = v1.x / divider,
                y = v1.y / divider,
            };
            return v;
        }

        public bool Equals(Vector2D other)
        {
            if (x.Equals(other.x) && y.Equals(other.y)) return true;
            return false;
        }

    }
}
