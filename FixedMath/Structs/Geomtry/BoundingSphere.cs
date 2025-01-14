﻿/**
Source:
https://github.com/sam-vdp/bepuphysics1int/blob/master/BEPUutilities/BoundingSphere.cs
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedMath.Geomtry
{
    /// <summary>
    /// Provides XNA-like bounding sphere functionality.
    /// </summary>
    public struct BoundingSphere
    {
        /// <summary>
        /// Radius of the sphere.
        /// </summary>
        public Fix64 Radius;
        /// <summary>
        /// Location of the center of the sphere.
        /// </summary>
        public FixVector3 Center;

        /// <summary>
        /// Constructs a new bounding sphere.
        /// </summary>
        /// <param name="center">Location of the center of the sphere.</param>
        /// <param name="radius">Radius of the sphere.</param>
        public BoundingSphere(FixVector3 center, Fix64 radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
    }
}
