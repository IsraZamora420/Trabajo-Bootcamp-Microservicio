using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class OpcionServices : IOpcion
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public OpcionServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetOpcion(int opcionId)
        {
            var respuesta = new Respuesta();
            try
            {
                if (opcionId == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await _context.Opcions.ToListAsync();
                    respuesta.Mensaje = "Opciones listadas";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
            }

            return respuesta;
        }

        public async Task<Respuesta> CreateOpcion(IOpcion opcion)
        {
            var respuesta = new Respuesta();
            try
            {
                if (opcion != null)
                {
                    _context.Add(opcion);
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

        public Task<Respuesta> CreateOpcion(Opcion opcion)
        {
            throw new NotImplementedException();
        }
    }
}
