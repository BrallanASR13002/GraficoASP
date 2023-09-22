﻿using System;
using System.Collections.Generic;

namespace Graficos.Models;

public partial class DetalleVentum
{
    public int IddetalleVenta { get; set; }

    public int? Idventa { get; set; }

    public string? NombreProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Ventum? IdventaNavigation { get; set; }
}
