using System;
using System.Collections.Generic;

namespace Trabajo_Bootcamp_Microservicio.Models;

public partial class UsuarioAutenticacion
{
    public string? Username { get; set; }

    public string? Userpassword { get; set; }

    public long? UsuId { get; set; }
}
