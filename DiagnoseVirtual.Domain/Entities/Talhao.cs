﻿using NetTopologySuite.Geometries;

namespace DiagnoseVirtual.Domain.Entities
{
    public class Talhao : BaseEntity
    {
        public virtual Geometry Geometria { get; set; }
        public virtual Lavoura Lavoura { get; set; }
    }
}