

namespace FixedMath.Geomtry
{
    /// <summary>
    /// Provides XNA-like plane functionality.
    /// </summary>
    public struct Plane
    {
        /// <summary>
        /// Normal of the plane.
        /// </summary>
        public FixVector3 Normal;
        /// <summary>
        /// Negative distance to the plane from the origin along the normal.
        /// </summary>
        public Fix64 D;


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="position">A point on the plane.</param>
        /// <param name="normal">The normal of the plane.</param>
        public Plane(in FixVector3 position, in FixVector3 normal)
        {
            Fix64 d;
            FixVector3.Dot(in position, in normal, out d);
            D = -d;
            Normal = normal;
        }


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="position">A point on the plane.</param>
        /// <param name="normal">The normal of the plane.</param>
        public Plane(FixVector3 position, FixVector3 normal)
            : this(in position, in normal)
        {

        }


        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="normal">Normal of the plane.</param>
        /// <param name="d">Negative distance to the plane from the origin along the normal.</param>
        public Plane(FixVector3 normal, Fix64 d)
            : this(in normal, d)
        {
        }

        /// <summary>
        /// Constructs a new plane.
        /// </summary>
        /// <param name="normal">Normal of the plane.</param>
        /// <param name="d">Negative distance to the plane from the origin along the normal.</param>
        public Plane(in FixVector3 normal, Fix64 d)
        {
            this.Normal = normal;
            this.D = d;
        }

        /// <summary>
        /// Gets the dot product of the position offset from the plane along the plane's normal.
        /// </summary>
        /// <param name="v">Position to compute the dot product of.</param>
        /// <param name="dot">Dot product.</param>
        public void DotCoordinate(in FixVector3 v, out Fix64 dot)
        {
            dot = Normal.x * v.x + Normal.y * v.y + Normal.z * v.z + D;
        }
    }
}
