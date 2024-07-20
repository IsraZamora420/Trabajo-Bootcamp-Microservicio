using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Globalization;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class TarjetaCreditoServices : ITarjetaCredito
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public TarjetaCreditoServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> PostTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.TarjetaCreditos.OrderByDescending(t => t.TarjetacredId).Select(t => t.TarjetacredId).FirstOrDefault();

                tarjetaCredito.TarjetacredId = Convert.ToInt32(query) + 1;
                tarjetaCredito.FechaHoraReg = DateTime.Now;
                tarjetaCredito.FechaHoraAct = DateTime.Now;

                _context.TarjetaCreditos.Add(tarjetaCredito);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("ProductoServices", "PostTarjetaCredito", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetTarjetaCredito(int tarjetaCredito)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<TarjetaCreditoDto> query = (from t in _context.TarjetaCreditos
                                                       join i in _context.Industria on t.IndustriaId equals i.IndustriaId
                                                       select new TarjetaCreditoDto
                                                       {
                                                           TarjetacredId = t.TarjetacredId,
                                                           TarjetacredDescripcion = t.TarjetacredDescripcion,
                                                           IndustriaId = t.IndustriaId,
                                                           IndustriaNombre = i.IndustriaDescripcion,
                                                           FechaHoraAct = t.FechaHoraAct,
                                                           UsuIdReg = t.UsuIdReg,
                                                           UsuIdAct = t.UsuIdAct
                                                       });

                if (tarjetaCredito != 0)
                {
                    query = query.Where(p => p.TarjetacredId == tarjetaCredito);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("TarjetaCreditoServices", "GetTarjetaCredito", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutTarjetaCredito(TarjetaCredito tarjetaCredito)
        {
            var respuesta = new Respuesta();
            try
            {
                tarjetaCredito.FechaHoraAct = DateTime.Now;
                _context.TarjetaCreditos.Update(tarjetaCredito);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("TarjetaCreditoServices", "PutTarjetaCredito", ex.Message);
            }
            return respuesta;
        }
    }
}