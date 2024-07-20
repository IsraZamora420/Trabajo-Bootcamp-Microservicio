using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class MovimientoDetPagosServices : IMovimientoDetPagos
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public MovimientoDetPagosServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetMovimientoDetPagos(int idMovimientoDetPagos)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<MovimientoDetPagosDto> query = (from mpa in _context.MovimientoDetPagos
                                                           join fp in _context.FormaPagos on mpa.FpagoId equals fp.FpagoId
                                                           join ind in _context.Industria on mpa.IndustriaId equals ind.IndustriaId
                                                           join tc in _context.TarjetaCreditos on mpa.TarjetacredId equals tc.TarjetacredId
                                                           join cl in _context.Clientes on mpa.ClienteId equals cl.ClienteId
                                                           select new MovimientoDetPagosDto
                                                           {
                                                               MovidetPagoId = mpa.MovidetPagoId,
                                                               MovicabId = mpa.MovicabId,
                                                               FpagoId = mpa.FpagoId,
                                                               FpagoNombre = fp.FpagoDescripcion,
                                                               ValorPagado = mpa.ValorPagado,
                                                               IndustriaId = mpa.IndustriaId,
                                                               IndustriaNombre = ind.IndustriaDescripcion,
                                                               Lote = mpa.Lote,
                                                               Voucher = mpa.Voucher,
                                                               TarjetacredId = mpa.IndustriaId,
                                                               TarjetacredNombre = tc.TarjetacredDescripcion,
                                                               BancoId = mpa.BancoId,
                                                               ComprobanteId = mpa.ComprobanteId,
                                                               FechaPago = mpa.FechaPago,
                                                               ClienteId = mpa.IndustriaId,
                                                               ClienteNombre = cl.ClienteNombre1 + " " + cl.ClienteNombre2 + " " + cl.ClienteApellido1 + " " + cl.ClienteApellido2
                                                           });
                if (idMovimientoDetPagos != 0)
                {
                    query = query.Where(x => x.MovidetPagoId == idMovimientoDetPagos);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetPagosService", "GetMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostMovimientoDetPagos(MovimientoDetPago movimientoDetPago)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.MovimientoDetPagos.OrderByDescending(x => x.MovidetPagoId).Select(x => x.MovidetPagoId).FirstOrDefault();

                movimientoDetPago.MovidetPagoId = Convert.ToInt32(query) + 1;

                DateTime fechaActual = DateTime.Now;
                string fechaComoString = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
                movimientoDetPago.FechaPago = fechaComoString;

                _context.MovimientoDetPagos.Add(movimientoDetPago);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetPagosService", "PostMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutMovimientoDetPagos(MovimientoDetPago movimientoDetPago)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.MovimientoDetPagos.Update(movimientoDetPago);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetPagosService", "PutMovimientoDetPagos", ex.Message);
            }
            return respuesta;
        }
    }
}
