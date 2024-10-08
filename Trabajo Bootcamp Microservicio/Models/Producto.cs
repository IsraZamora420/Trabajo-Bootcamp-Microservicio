﻿using System;
using System.Collections.Generic;

namespace Trabajo_Bootcamp_Microservicio.Models;

public partial class Producto
{
    public int ProdId { get; set; }

    public string? ProdDescripcion { get; set; }

    public decimal? ProdUltPrecio { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public int? Estado { get; set; }

    public int? CategoriaId { get; set; }

    public int? EmpresaId { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Categorium? Categoria { get; set; }

    public virtual ICollection<MovimientoDetProducto> MovimientoDetProductos { get; set; } = new List<MovimientoDetProducto>();
}
