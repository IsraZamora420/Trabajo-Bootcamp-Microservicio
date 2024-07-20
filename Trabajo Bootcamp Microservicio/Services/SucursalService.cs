using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class SucursalService : ISucursal
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public SucursalService(BaseErpContext context)
        {
            _context = context;
        }

        public async Task<Respuesta> GetSucursal(int SucursalId, string? SucursalRuc, string? SucursalNombre)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.codigo = "000";

                if (SucursalId != null && SucursalId != 0 && !string.IsNullOrEmpty(SucursalRuc) && !string.IsNullOrEmpty(SucursalNombre))
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.SucursalId == SucursalId && s.SucursalRuc == SucursalRuc && s.SucursalNombre == SucursalNombre && s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }
                else if (SucursalId != null && SucursalId != 0 && string.IsNullOrEmpty(SucursalRuc) && string.IsNullOrEmpty(SucursalNombre))
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.SucursalId == SucursalId && s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }
                else if (string.IsNullOrEmpty(SucursalRuc) && string.IsNullOrEmpty(SucursalNombre) && SucursalId == 0)
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }
                else if (!string.IsNullOrEmpty(SucursalRuc) && SucursalId == 0 && string.IsNullOrEmpty(SucursalNombre))
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.SucursalRuc == SucursalRuc && s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }
                else if (string.IsNullOrEmpty(SucursalRuc) && !string.IsNullOrEmpty(SucursalNombre) && SucursalId == 0)
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.SucursalNombre.Contains(SucursalNombre) && s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }
                else if (SucursalId == 0 && !string.IsNullOrEmpty(SucursalRuc) && !string.IsNullOrEmpty(SucursalNombre))
                {
                    respuesta.data = await (from s in _context.Sucursals
                                            join e in _context.Empresas on s.EmpresaId equals e.EmpresaId
                                            where s.SucursalRuc == SucursalRuc && s.SucursalNombre == SucursalNombre && s.Estado.Value == 1
                                            select new SucursalDto
                                            {
                                                SucursalId = s.SucursalId,
                                                SucursalNombre = s.SucursalNombre,
                                                SucursalDireccion = s.SucursalDireccion,
                                                SucursalTelefono = s.SucursalTelefono,
                                                Estado = s.Estado,
                                                FechaHoraReg = s.FechaHoraReg,
                                                UsuIdReg = s.UsuIdReg,
                                                FechaHoraAct = s.FechaHoraAct,
                                                UsuIdAct = s.UsuIdAct,
                                                EmpresaId = e.EmpresaId,
                                                EmpresaNombre = e.EmpresaNombre
                                            }).ToListAsync();
                }

                respuesta.mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("SucursalService", "GetSucursal", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Sucursals.OrderByDescending(x => x.SucursalId).FirstOrDefault();

                sucursal.SucursalId = Convert.ToInt32(query) + 1;
                sucursal.FechaHoraAct = DateTime.Now;
                sucursal.FechaHoraReg = DateTime.Now;

                _context.Sucursals.Add(sucursal);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {

                respuesta.codigo = "000";
                respuesta.mensaje = $"Ocurrió un error al procesar la solicitud: {ex.Message}";
                Log.LogErrorMetodos("SucursalService", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutSucursal(Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                sucursal.FechaHoraAct = DateTime.Now;
                _context.Sucursals.Update(sucursal);
                await _context.SaveChangesAsync();

                respuesta.codigo = "000";
                respuesta.mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.codigo = "000";
                respuesta.mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("SucursalService", "PutSucursal", ex.Message);
            }
            return respuesta;
        }
    }
}
