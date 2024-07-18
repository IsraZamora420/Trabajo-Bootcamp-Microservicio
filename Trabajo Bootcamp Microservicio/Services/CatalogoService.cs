using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Utilities;
using Trabajo_Bootcamp_Microservicio.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class CatalogoService: ICatalogo
    {
        private readonly VentasErpContext _context;
        private ControlError Log = new ControlError();
        public CatalogoService(VentasErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetRol()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Rols.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetRol", ex.Message);
            }
            return respuesta;
        }

    }
}
