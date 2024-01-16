/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/Ray.cs
*/
using System;

namespace FixedMath.Geomtry
{
    /// <summary>
    /// Provides XNA-like ray functionality.
    /// </summary>
    public struct Ray
    {
        /// <summary>
        /// Starting position of the ray.
        /// </summary>
        public FixVector3 Position;
        /// <summary>
        /// Direction in which the ray points.
        /// </summary>
        public FixVector3 Direction;


        /// <summary>
        /// Constructs a new ray.
        /// </summary>
        /// <param name="position">Starting position of the ray.</param>
        /// <param name="direction">Direction in which the ray points.</param>
        public Ray(FixVector3 position, FixVector3 direction)
        {
            this.Position = position;
            this.Direction = direction;
        }



        /// <summary>
        /// Determines if and when the ray intersects the bounding box.
        /// </summary>
        /// <param name="boundingBox">Bounding box to test against.</param>
        /// <param name="t">The length along the ray to the impact, if any impact occurs.</param>
        /// <returns>True if the ray intersects the target, false otherwise.</returns>
        public bool Intersects(in BoundingBox boundingBox, out Fix64 t)
        {
            Fix64 tmin = F64.C0, tmax = Fix64.MaxValue;
            if (Fix64.Abs(Direction.x) < Fix64.Epsilon)
            {
                if (Position.x < boundingBox.Min.x || Position.x > boundingBox.Max.x)
                {
                    //If the ray isn't pointing along the axis at all, and is outside of the box's interval, then it
                    //can't be intersecting.
                    t = F64.C0;
                    return false;
                }
            }
            else
            {
                var inverseDirection = F64.C1 / Direction.x;
                var t1 = (boundingBox.Min.x - Position.x) * inverseDirection;
                var t2 = (boundingBox.Max.x - Position.x) * inverseDirection;
                if (t1 > t2)
                {
                    Fix64 temp = t1;
                    t1 = t2;
                    t2 = temp;
                }
                tmin = Fix64.Max(tmin, t1);
                tmax = Fix64.Min(tmax, t2);
                if (tmin > tmax)
                {
                    t = F64.C0;
                    return false;
                }
            }
            if (Fix64.Abs(Direction.y) < Fix64.Epsilon)
            {
                if (Position.y < boundingBox.Min.y || Position.y > boundingBox.Max.y)
                {
                    //If the ray isn't pointing along the axis at all, and is outside of the box's interval, then it
                    //can't be intersecting.
                    t = F64.C0;
                    return false;
                }
            }
            else
            {
                var inverseDirection = F64.C1 / Direction.y;
                var t1 = (boundingBox.Min.y - Position.y) * inverseDirection;
                var t2 = (boundingBox.Max.y - Position.y) * inverseDirection;
                if (t1 > t2)
                {
                    Fix64 temp = t1;
                    t1 = t2;
                    t2 = temp;
                }
                tmin = Fix64.Max(tmin, t1);
                tmax = Fix64.Min(tmax, t2);
                if (tmin > tmax)
                {
                    t = F64.C0;
                    return false;
                }
            }
            if (Fix64.Abs(Direction.z) < Fix64.Epsilon)
            {
                if (Position.z < boundingBox.Min.z || Position.z > boundingBox.Max.z)
                {
                    //If the ray isn't pointing along the axis at all, and is outside of the box's interval, then it
                    //can't be intersecting.
                    t = F64.C0;
                    return false;
                }
            }
            else
            {
                var inverseDirection = F64.C1 / Direction.z;
                var t1 = (boundingBox.Min.z - Position.z) * inverseDirection;
                var t2 = (boundingBox.Max.z - Position.z) * inverseDirection;
                if (t1 > t2)
                {
                    Fix64 temp = t1;
                    t1 = t2;
                    t2 = temp;
                }
                tmin = Fix64.Max(tmin, t1);
                tmax = Fix64.Min(tmax, t2);
                if (tmin > tmax)
                {
                    t = F64.C0;
                    return false;
                }
            }
            t = tmin;
            return true;
        }

        /// <summary>
        /// Determines if and when the ray intersects the bounding box.
        /// </summary>
        /// <param name="boundingBox">Bounding box to test against.</param>
        /// <param name="t">The length along the ray to the impact, if any impact occurs.</param>
        /// <returns>True if the ray intersects the target, false otherwise.</returns>
        public bool Intersects(BoundingBox boundingBox, out Fix64 t)
        {
            return Intersects(in boundingBox, out t);
        }

        /// <summary>
        /// Determines if and when the ray intersects the plane.
        /// </summary>
        /// <param name="plane">Plane to test against.</param>
        /// <param name="t">The length along the ray to the impact, if any impact occurs.</param>
        /// <returns>True if the ray intersects the target, false otherwise.</returns>
        public bool Intersects(in Plane plane, out Fix64 t)
        {
            Fix64 velocity;
            FixVector3.Dot(in Direction, in plane.Normal, out velocity);
            if (Fix64.Abs(velocity) < Fix64.Epsilon)
            {
                t = F64.C0;
                return false;
            }
            Fix64 distanceAlongNormal;
            FixVector3.Dot(in Position, in plane.Normal, out distanceAlongNormal);
            distanceAlongNormal += plane.D;
            t = -distanceAlongNormal / velocity;
            return t >= -Fix64.Epsilon;
        }

        /// <summary>
        /// Determines if and when the ray intersects the plane.
        /// </summary>
        /// <param name="plane">Plane to test against.</param>
        /// <param name="t">The length along the ray to the impact, if any impact occurs.</param>
        /// <returns>True if the ray intersects the target, false otherwise.</returns>
        public bool Intersects(Plane plane, out Fix64 t)
        {
            return Intersects(in plane, out t);
        }

        /// <summary>
        /// Computes a point along a ray given the length along the ray from the ray position.
        /// </summary>
        /// <param name="t">Length along the ray from the ray position in terms of the ray's direction.</param>
        /// <param name="v">Point along the ray at the given location.</param>
        public void GetPointOnRay(Fix64 t, out FixVector3 v)
        {
            FixVector3.Multiply(in Direction, t, out v);
            FixVector3.Add(in v, in Position, out v);
        }
    }
}
