using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class UsuarioPermisoServices
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public UsuarioPermisoServices(BaseErpContext context)
        {
           this._context = context;
        }

        public async Task<Respuesta> GetUsuarioPermiso(int PermisoId)
        {
            var respuesta = new Respuesta();
            try
            {
                if (PermisoId == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.UsuarioPermisos.ToListAsync();
                    respuesta.Mensaje = "Permisos de Usuario listados";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
            }

            return respuesta;
        }

        public async Task<Respuesta> CreateUsuarioPermiso(UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                if (usuarioPermiso != null)
                {
                    _context.Add(usuarioPermiso);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se insertó correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";

            }
            return respuesta;
        }
    }
}
