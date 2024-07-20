using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class MovimientoDetProdServices : IMovimientoDetProd
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public MovimientoDetProdServices(BaseErpContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> GetMovimientoDetProd(int idMovimientoDetProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<MovimientoDetProductoDto> query = (from mpd in _context.MovimientoDetProductos
                                                              join mc in _context.MovimientoCabs on mpd.MovicabId equals mc.MovicabId
                                                              join pp in _context.Productos on mpd.ProductoId equals pp.ProdId
                                                              select new MovimientoDetProductoDto
                                                              {
                                                                  MovidetProdId = mpd.MovidetProdId,
                                                                  MovicabId = mc.MovicabId,
                                                                  ProductoId = mpd.ProductoId,
                                                                  ProductoNombre = pp.ProdDescripcion,
                                                                  Cantidad = mpd.Cantidad,
                                                                  Precio = mpd.Precio,
                                                                  Estado = mpd.Estado,
                                                                  FechaHoraReg = mpd.FechaHoraReg,
                                                                  FechaHoraAct = mpd.FechaHoraAct,
                                                                  UsuIdReg = mpd.UsuIdReg,
                                                                  UsuIdAct = mpd.UsuIdAct
                                                              });

                if (idMovimientoDetProducto != 0)
                {
                    query = query.Where(mc => mc.MovidetProdId == idMovimientoDetProducto);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetProdServices", "GetMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostMovimientoDetProd(MovimientoDetProducto movimientoDetProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.MovimientoDetProductos.OrderByDescending(x => x.MovidetProdId).Select(x => x.MovidetProdId).FirstOrDefault();

                movimientoDetProducto.MovidetProdId = Convert.ToInt32(query) + 1;
                movimientoDetProducto.FechaHoraAct = DateTime.Now;
                movimientoDetProducto.FechaHoraReg = DateTime.Now;

                _context.MovimientoDetProductos.Add(movimientoDetProducto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetProdServices", "PostMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutMovimientoDetProd(MovimientoDetProducto movimientoDetProducto)
        {
            var respuesta = new Respuesta();
            try
            {
                movimientoDetProducto.FechaHoraAct = DateTime.Now;
                _context.MovimientoDetProductos.Update(movimientoDetProducto);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoDetProdServices", "PutMovimientoDetProd", ex.Message);
            }
            return respuesta;
        }
    }
}
