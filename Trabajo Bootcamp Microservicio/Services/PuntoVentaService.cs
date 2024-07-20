using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class PuntoVentaService : IPuntoVenta
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public PuntoVentaService(BaseErpContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> GetPuntoEmisionSRI(int PuntoEmisionId, string? PuntoEmision, int? EmpresaId, int? SucursalId, string? CodEstablecimientoSri)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.codigo = "000";

                if (PuntoEmisionId != 0 && !string.IsNullOrEmpty(PuntoEmision) && EmpresaId != null && SucursalId != null && !string.IsNullOrEmpty(CodEstablecimientoSri))
                {
                    respuesta.data = await (from pe in _context.PuntoEmisionSris
                                            join e in _context.Empresas on pe.EmpresaId equals e.EmpresaId
                                            join s in _context.Sucursals on pe.SucursalId equals s.SucursalId
                                            where pe.PuntoEmisionId == PuntoEmisionId && pe.PuntoEmision == PuntoEmision && pe.EmpresaId == EmpresaId && pe.SucursalId == SucursalId && pe.CodEstablecimientoSri == CodEstablecimientoSri && pe.Estado == 1
                                            select new PuntoEmisionSriDto
                                            {
                                                PuntoEmisionId = pe.PuntoEmisionId,
                                                PuntoEmision = pe.PuntoEmision,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                CodEstablecimientoSri = pe.CodEstablecimientoSri,
                                                UltSecuencia = pe.UltSecuencia,
                                                Estado = pe.Estado,
                                                FechaHoraReg = pe.FechaHoraReg,
                                                UsuIdReg = pe.UsuIdReg,
                                                FechaHoraAct = pe.FechaHoraAct,
                                                UsuIdAct = pe.UsuIdAct
                                            }).ToListAsync();
                }
                else if (PuntoEmisionId != 0)
                {
                    respuesta.data = await (from pe in _context.PuntoEmisionSris
                                            join e in _context.Empresas on pe.EmpresaId equals e.EmpresaId
                                            join s in _context.Sucursals on pe.SucursalId equals s.SucursalId
                                            where pe.PuntoEmisionId == PuntoEmisionId && pe.Estado == 1
                                            select new PuntoEmisionSriDto
                                            {
                                                PuntoEmisionId = pe.PuntoEmisionId,
                                                PuntoEmision = pe.PuntoEmision,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                CodEstablecimientoSri = pe.CodEstablecimientoSri,
                                                UltSecuencia = pe.UltSecuencia,
                                                Estado = pe.Estado,
                                                FechaHoraReg = pe.FechaHoraReg,
                                                UsuIdReg = pe.UsuIdReg,
                                                FechaHoraAct = pe.FechaHoraAct,
                                                UsuIdAct = pe.UsuIdAct
                                            }).ToListAsync();
                }
                // Añade aquí otros condicionales según sea necesario

                respuesta.mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "GetPuntoEmisionSRI", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetPuntoVenta(int PuntovtaId, string? PuntovtaNombre, int? PuntoEmisionId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.codigo = "000";

                if (PuntovtaId != 0 && !string.IsNullOrEmpty(PuntovtaNombre) && PuntoEmisionId != null)
                {
                    respuesta.data = await (from pv in _context.PuntoVenta
                                            join pe in _context.PuntoEmisionSris on pv.PuntoEmisionId equals pe.PuntoEmisionId
                                            join s in _context.Sucursals on pv.SucursalId equals s.SucursalId
                                            where pv.PuntovtaId == PuntovtaId && pv.PuntovtaNombre == PuntovtaNombre && pv.PuntoEmisionId == PuntoEmisionId && pv.Estado == 1
                                            select new PuntoVentaDto
                                            {
                                                PuntovtaId = pv.PuntovtaId,
                                                PuntovtaNombre = pv.PuntovtaNombre,
                                                PuntoEmisionId = pe.PuntoEmisionId,
                                                PuntoEmision = pe.PuntoEmision,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                Estado = pv.Estado,
                                                FechaHoraReg = pv.FechaHoraReg,
                                                UsuIdReg = pv.UsuIdReg,
                                                FechaHoraAct = pv.FechaHoraAct,
                                                UsuIdAct = pv.UsuIdAct
                                            }).ToListAsync();
                }
                else if (PuntovtaId != 0)
                {
                    respuesta.data = await (from pv in _context.PuntoVenta
                                            join pe in _context.PuntoEmisionSris on pv.PuntoEmisionId equals pe.PuntoEmisionId
                                            join s in _context.Sucursals on pv.SucursalId equals s.SucursalId
                                            where pv.PuntovtaId == PuntovtaId && pv.Estado == 1
                                            select new PuntoVentaDto
                                            {
                                                PuntovtaId = pv.PuntovtaId,
                                                PuntovtaNombre = pv.PuntovtaNombre,
                                                PuntoEmisionId = pe.PuntoEmisionId,
                                                PuntoEmision = pe.PuntoEmision,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                Estado = pv.Estado,
                                                FechaHoraReg = pv.FechaHoraReg,
                                                UsuIdReg = pv.UsuIdReg,
                                                FechaHoraAct = pv.FechaHoraAct,
                                                UsuIdAct = pv.UsuIdAct
                                            }).ToListAsync();
                }

                respuesta.mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "GetPuntoVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostPuntoEmisionSRI(PuntoEmisionSri puntoSRI)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.PuntoEmisionSris.OrderByDescending(x => x.PuntoEmisionId).FirstOrDefault();

                puntoSRI.PuntoEmisionId = Convert.ToInt32(query) + 1;
                puntoSRI.FechaHoraReg = DateTime.Now;
                puntoSRI.FechaHoraAct = DateTime.Now;

                _context.PuntoEmisionSris.Add(puntoSRI);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "PostPuntoEmisionSRI", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostPuntoVenta(PuntoVentum puntoVenta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.PuntoVenta.OrderByDescending(x => x.PuntovtaId).FirstOrDefault();

                puntoVenta.PuntovtaId = Convert.ToInt32(query) + 1;
                puntoVenta.FechaHoraReg = DateTime.Now;
                puntoVenta.FechaHoraAct = DateTime.Now;

                _context.PuntoVenta.Add(puntoVenta);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "PostPuntoVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutPuntoEmisionSRI(PuntoEmisionSri puntoSRI)
        {
            var respuesta = new Respuesta();
            try
            {
                puntoSRI.FechaHoraAct = DateTime.Now;
                _context.PuntoEmisionSris.Update(puntoSRI);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "PutPuntoEmisionSRI", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutPuntoVenta(PuntoVentum puntoVenta)
        {
            var respuesta = new Respuesta();
            try
            {
                puntoVenta.FechaHoraAct = DateTime.Now;
                _context.PuntoVenta.Update(puntoVenta);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("PuntoVentaService", "PutPuntoVenta", ex.Message);
            }
            return respuesta;
        }
    }
}
