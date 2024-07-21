using Microsoft.EntityFrameworkCore;
using System;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class UsuarioPermisoServices: IUsuarioPermiso
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public UsuarioPermisoServices(BaseErpContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> PostUsuarioPermiso(UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.UsuarioPermisos.OrderByDescending(u => u.PermisoId).Select(u => u.PermisoId).FirstOrDefault();

                usuarioPermiso.PermisoId = Convert.ToInt32(query) + 1;
                usuarioPermiso.FechaHoraReg = DateTime.Now;
                usuarioPermiso.FechaHoraAct = DateTime.Now;

                _context.UsuarioPermisos.Add(usuarioPermiso);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioPermisoServices", "PostUsuarioPermiso", ex.Message);
            }

            return respuesta;
        }

        public async Task<Respuesta> GetUsuarioPermiso(int usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<UsuarioPermisoDto> query = (from u in _context.UsuarioPermisos
                                                       join m in _context.Modulos on u.ModuloId equals m.ModuloId
                                                       join o in _context.Opcions on u.OpcionId equals o.OpcionId
                                                       join us in _context.Usuarios on u.UsuId equals us.UsuId
                                                       select new UsuarioPermisoDto
                                                       {
                                                           PermisoId = u.PermisoId,
                                                           ModuloId = u.ModuloId,
                                                           ModuloDescripcion = m.ModuloDescripcion,
                                                           OpcionId = u.OpcionId,
                                                           OpcionNombre = o.OpcionDescripcion,
                                                           UsuId = u.UsuId,
                                                           UsuNombre = us.UsuNombre,
                                                           EstadoPermiso = u.EstadoPermiso,
                                                           FechaHoraReg = u.FechaHoraReg,
                                                           FechaHoraAct = u.FechaHoraAct,
                                                           UsuIdReg = u.UsuIdReg,
                                                           UsuIdAct = u.UsuIdAct
                                                       });

                if (usuarioPermiso != 0)
                {
                    query = query.Where(u => u.UsuId == usuarioPermiso);
                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";
            }

            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioPermisoServices", "GetUsuarioPermiso", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutUsuarioPermiso(UsuarioPermiso usuarioPermiso)
        {
            var respuesta = new Respuesta();
            try
            {
                usuarioPermiso.FechaHoraAct = DateTime.Now;
                _context.UsuarioPermisos.Update(usuarioPermiso);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioPermisoServices", "PutUsuarioPermiso", ex.Message);
            }
            return respuesta;
        }
    }
}
