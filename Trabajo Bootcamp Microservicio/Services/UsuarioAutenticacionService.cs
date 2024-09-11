using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class UsuarioAutenticacionService : IUsuarioAutenticacion
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public UsuarioAutenticacionService(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetUsuarioAutenticacion(string? usuario, string? contrasenia)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.UsuarioAutenticacions.Where(i => i.Username.Equals(usuario) && i.Userpassword.Equals(contrasenia)).ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioAutenticacion", "GetUsuarioAutenticacion", ex.Message);
            }

            return respuesta;
        }
    }
}
