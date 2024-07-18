using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public CatalogoServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetPais(int idpais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (idpais == 0)
                {
                    respuesta.Data = await _context.Pais.ToListAsync();
                }
                else if (idpais != 0)
                {
                    respuesta.Data = await _context.Pais.Where(p => p.PaisId.Equals(idpais)).ToListAsync();
                }

                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("PaisService", "GetPais", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostPais(Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Pais.OrderByDescending(x => x.PaisId).Select(x => x.PaisId).FirstOrDefault();

                pais.PaisId = Convert.ToInt32(query) + 1;
                pais.FechaHoraReg = DateTime.Now;
                pais.FechaHoraAct = DateTime.Now;

                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("PaisServices", "PostPais", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutPais(Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                pais.FechaHoraAct = DateTime.Now;
                _context.Pais.Update(pais);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("PaisServices", "PutPais", ex.Message);
            }
            return respuesta;
        }
    }
}
