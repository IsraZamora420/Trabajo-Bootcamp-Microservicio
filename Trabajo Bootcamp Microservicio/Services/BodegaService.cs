﻿using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class BodegaService : IBodega
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public BodegaService(BaseErpContext context)
        {
            _context = context;
        }


        public async Task<Respuesta> GetBodega(int BodegaId, string? BodegaNombre, int? SucursalId)
        {
            var respuesta = new Respuesta();
            try
            {
                if (BodegaId != null && BodegaId != 0 && !string.IsNullOrEmpty(BodegaNombre) && SucursalId != null && SucursalId != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from b in _context.Bodegas
                                            join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                            where b.Estado.HasValue && b.Estado.Value == 1
                                            && b.BodegaId.Equals(BodegaId)
                                            && b.BodegaNombre.Equals(BodegaNombre)
                                            && b.SucursalId.Equals(SucursalId)
                                            select new BodegaSucursalDto
                                            {
                                                BodegaId = b.BodegaId,
                                                BodegaNombre = b.BodegaNombre,
                                                BodegaDireccion = b.BodegaDireccion,
                                                BodegaTelefono = b.BodegaTelefono,
                                                Estado = b.Estado,
                                                FechaHoraReg = b.FechaHoraReg,
                                                FechaHoraAct = b.FechaHoraAct,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (BodegaId != null && BodegaId != 0 && string.IsNullOrEmpty(BodegaNombre) && SucursalId == null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from b in _context.Bodegas
                                            join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                            where b.Estado.HasValue && b.Estado.Value == 1
                                            && b.BodegaId.Equals(BodegaId)
                                            select new BodegaSucursalDto
                                            {
                                                BodegaId = b.BodegaId,
                                                BodegaNombre = b.BodegaNombre,
                                                BodegaDireccion = b.BodegaDireccion,
                                                BodegaTelefono = b.BodegaTelefono,
                                                Estado = b.Estado,
                                                FechaHoraReg = b.FechaHoraReg,
                                                FechaHoraAct = b.FechaHoraAct,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (!string.IsNullOrEmpty(BodegaNombre) && BodegaId == null && SucursalId == null)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from b in _context.Bodegas
                                            join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                            where b.Estado.HasValue && b.Estado.Value == 1
                                            && b.BodegaNombre.Contains(BodegaNombre)
                                            select new BodegaSucursalDto
                                            {
                                                BodegaId = b.BodegaId,
                                                BodegaNombre = b.BodegaNombre,
                                                BodegaDireccion = b.BodegaDireccion,
                                                BodegaTelefono = b.BodegaTelefono,
                                                Estado = b.Estado,
                                                FechaHoraReg = b.FechaHoraReg,
                                                FechaHoraAct = b.FechaHoraAct,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (SucursalId != null && SucursalId != 0 && BodegaId == null && string.IsNullOrEmpty(BodegaNombre))
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from b in _context.Bodegas
                                            join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                            where b.Estado.HasValue && b.Estado.Value == 1
                                            && b.SucursalId.Equals(SucursalId)
                                            select new BodegaSucursalDto
                                            {
                                                BodegaId = b.BodegaId,
                                                BodegaNombre = b.BodegaNombre,
                                                BodegaDireccion = b.BodegaDireccion,
                                                BodegaTelefono = b.BodegaTelefono,
                                                Estado = b.Estado,
                                                FechaHoraReg = b.FechaHoraReg,
                                                FechaHoraAct = b.FechaHoraAct,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from b in _context.Bodegas
                                            join s in _context.Sucursals on b.SucursalId equals s.SucursalId
                                            where b.Estado.HasValue && b.Estado.Value == 1
                                            select new BodegaSucursalDto
                                            {
                                                BodegaId = b.BodegaId,
                                                BodegaNombre = b.BodegaNombre,
                                                BodegaDireccion = b.BodegaDireccion,
                                                BodegaTelefono = b.BodegaTelefono,
                                                Estado = b.Estado,
                                                FechaHoraReg = b.FechaHoraReg,
                                                FechaHoraAct = b.FechaHoraAct,
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("BodegaService", "GetBodega", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostBodega(Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Bodegas.OrderByDescending(x => x.BodegaId).Select(x=>x.BodegaId).FirstOrDefault();

                bodega.BodegaId = Convert.ToInt32(query) + 1;
                bodega.FechaHoraAct = DateTime.Now;
                bodega.FechaHoraReg = DateTime.Now;

                _context.Bodegas.Add(bodega);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {

                respuesta.Cod = "000";
                respuesta.Mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("BodegaService", "PostBodega", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutBodega(Bodega bodega)
        {
            var respuesta = new Respuesta();
            try
            {
                bodega.FechaHoraAct = DateTime.Now;
                _context.Bodegas.Update(bodega);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("BodegaService", "PutBodega", ex.Message);
            }
            return respuesta;
        }
    }
}
