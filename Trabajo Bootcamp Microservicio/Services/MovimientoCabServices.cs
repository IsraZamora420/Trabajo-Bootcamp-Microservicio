using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class MovimientoCabServices : IMovimientoCab
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public MovimientoCabServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetMovimientoCab(int idMovimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<MovimientoCabDto> query = (from mc in _context.MovimientoCabs
                                                      join tm in _context.TipoMovimientos on mc.TipomovId equals tm.TipomovId
                                                      join em in _context.Empresas on mc.EmpresaId equals em.EmpresaId
                                                      join suc in _context.Sucursals on mc.SucursalId equals suc.SucursalId
                                                      join bb in _context.Bodegas on mc.BodegaId equals bb.BodegaId
                                                      join cl in _context.Clientes on mc.ClienteId equals cl.ClienteId
                                                      join pv in _context.PuntoVenta on mc.PuntovtaId equals pv.PuntovtaId
                                                      join pr in _context.Proveedors on mc.ProveedorId equals pr.ProvId
                                                      join us in _context.Usuarios on mc.UsuIdReg equals us.UsuIdReg
                                                      select new MovimientoCabDto
                                                      {
                                                          MovicabId = mc.MovicabId,
                                                          TipomovId = mc.TipomovId,
                                                          TipomovNombre = tm.TipomovDescrip,
                                                          TipomovIngEgr = tm.TipomovIngEgr,
                                                          EmpresaId = mc.EmpresaId,
                                                          EmpresaNombre = em.EmpresaNombre,
                                                          SucursalId = mc.SucursalId,
                                                          SucursalNombre = suc.SucursalNombre,
                                                          BodegaId = mc.BodegaId,
                                                          BodegaNombre = bb.BodegaNombre,
                                                          SecuenciaFactura = mc.SecuenciaFactura,
                                                          AutorizacionSri = mc.AutorizacionSri,
                                                          ClaveAcceso = mc.ClaveAcceso,
                                                          ClienteId = mc.ClienteId,
                                                          ClienteNombre = cl.ClienteNombre1 + " " + cl.ClienteNombre2 + " " + cl.ClienteApellido1 + " " + cl.ClienteApellido2,
                                                          PuntovtaId = mc.PuntovtaId,
                                                          PuntovtaNombre = pv.PuntovtaNombre,
                                                          Estado = mc.Estado,
                                                          ProveedorId = mc.ProveedorId,
                                                          ProveedorNombre = pr.ProvNomComercial,
                                                          FechaHoraAct = mc.FechaHoraAct,
                                                          FechaHoraReg = mc.FechaHoraReg,
                                                          UsuIdReg = mc.UsuIdReg,
                                                          UsuIdNombreReg = us.UsuNombre,
                                                          UsuIdAct = mc.UsuIdAct
                                                      });
                if (idMovimientoCab != 0)
                {
                    query = query.Where(mc => mc.MovicabId == idMovimientoCab);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoCabServices", "GetMovimientoCab", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostMovimientoCab(MovimientoCab movimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.MovimientoCabs.OrderByDescending(x => x.MovicabId).Select(x => x.MovicabId).FirstOrDefault();

                movimientoCab.MovicabId = Convert.ToInt32(query) + 1;
                movimientoCab.FechaHoraReg = DateTime.Now;
                movimientoCab.FechaHoraAct = DateTime.Now;

                _context.MovimientoCabs.Add(movimientoCab);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoCabServices", "PostMovimientoCab", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutMovimientoCab(MovimientoCab movimientoCab)
        {
            var respuesta = new Respuesta();
            try
            {
                movimientoCab.FechaHoraAct = DateTime.Now;
                _context.MovimientoCabs.Update(movimientoCab);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("MovimientoCabServices", "PutMovimientoCab", ex.Message);
            }
            return respuesta;
        }
    }
}
