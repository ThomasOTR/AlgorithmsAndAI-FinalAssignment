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
        /// <summary>
        /// Method to convert a vector to negative.
        /// </summary>
        /// <returns></returns>
        public Vector2D Negative()
        {
            return new Vector2D(-x, -y);
        }

        /// <summary>
        /// Method to get the Length.
        /// </summary>
        /// <returns></returns>
        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Method to get the squared version of Length()
        /// </summary>
        /// <returns></returns>
        public double LengthSquared()
        {
            return x * x + y * y;
        }

        /// <summary>
        /// Check if a Vector is in range of this vector.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public bool WithinRange(Vector2D v, double range)
        {
            return Distance(v) < range;
        }

        /// <summary>
        /// Method to normalize a Vector
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Method to perp a vector
        /// </summary>
        /// <returns></returns>
        public Vector2D Perp()
        {
            return new Vector2D(-y, x);
        }

        /// <summary>
        /// Method to get the distance to another Vector
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double Distance(Vector2D other)
        {
            return new Vector2D(x - other.x, y - other.y).Length();
        }

        /// <summary>
        /// Squared version of Distance()
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double DistanceSquared(Vector2D other)
        {
            return new Vector2D(x - other.x, y - other.y).LengthSquared();
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

        /// <summary>
        /// Method to receive a clone of this vector. This is used to hold the values of this vector while also using the values.
        /// </summary>
        /// <returns></returns>
        public Vector2D Clone()
        {
            return new Vector2D(x, y);
        }

        /// <summary>
        /// Method to add the values of a vector to this vector
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public Vector2D Add(Vector2D v1)
        {
            x += v1.x;
            y += v1.y;
            return this;
        }

        /// <summary>
        /// Operator version of Add()
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            Vector2D v = new()
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y
            };
            return v;
        }

        /// <summary>
        /// Method to subtract the values of a vector of this vector.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public Vector2D Subtract(Vector2D v1)
        {
            x -= v1.x;
            y -= v1.y;
            return this;
        }

        /// <summary>
        /// Operator version of Subtract()
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            Vector2D v = new()
            {
                x = v1.x - v2.x,
                y = v1.y - v2.y
            };
            return v;
        }
        /// <summary>
        /// Method to multiply the values of this vector with the multiplier parameter.
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public Vector2D Multiply(double multiplier)
        {
            x *= multiplier;
            y *= multiplier;
            return this;

        }

        /// <summary>
        /// Operator version of Multiply()
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static Vector2D operator *(Vector2D v1, double multiplier)
        {
            Vector2D v = new Vector2D
            {
                x = v1.x * multiplier,
                y = v1.y * multiplier,
            };
            return v;
        }

        /// <summary>
        /// Method to divide the values of this vector with the divider parameter.
        /// </summary>
        /// <param name="divider"></param>
        /// <returns></returns>
        public Vector2D Divide(double divider)
        {
            if (divider == 0 || x == 0 || y == 0) return this;
            else
            {
                x /= divider;
                y /= divider;
                return this;
            }
        }
        /// <summary>
        /// Operator version of Divide()
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="divider"></param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D v1, double divider)
        {
            if (divider == 0 || v1.x == 0 || v1.y == 0) return v1;
            else
            {
                Vector2D v = new Vector2D
                {
                    x = v1.x / divider,
                    y = v1.y / divider,
                };
                return v;
            }
        }

        /// <summary>
        /// A method to check if 2 Vector2D's are the same.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            else
            {
                Vector2D v = (Vector2D)obj;

                if (x.Equals(v.x) && y.Equals(v.y)) return true;
                return false;
            }
        }

        public override string ToString()
        {
            return $"Vector2D({x},{y})";
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
}
