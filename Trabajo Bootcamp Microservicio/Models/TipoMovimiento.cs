﻿using System;
using System.Collections.Generic;

namespace Trabajo_Bootcamp_Microservicio.Models;

public partial class TipoMovimiento
{
    public int TipomovId { get; set; }

    public string? TipomovDescrip { get; set; }

    public short? TipomovIngEgr { get; set; }

    public short? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public DateTime? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();
}
