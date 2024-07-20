using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class UsuarioRolServices : IUsuarioRol
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public UsuarioRolServices(BaseErpContext context)
        {
            this._context = context;
        }
       
        //-----------------------------------------------USUARIO_ROL--------------------------------------
        public async Task<Respuesta> GetUsuarioRol(int usurolId, int usulId, int rolId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                IQueryable<UsuarioRolDto> query = (from p in _context.UsuarioRols
                                               join c in _context.Usuarios on p.UsuId equals c.UsuId
                                               join r in _context.Rols on p.RolId equals r.RolId
                                                   select new UsuarioRolDto
                                               {
                                                   UsuRolId = p.UsuRolId,
                                                   UsuId = p.UsuId,
                                                   UsuNombre = c.UsuNombre,
                                                   RolId = p.RolId,
                                                   RolDescripcion = r.RolDescripcion,
                                                   Estado = p.Estado,
                                                   FechaHoraReg = p.FechaHoraReg,
                                                   FechaHoraAct = p.FechaHoraAct,
                                                   UsuIdAct = p.UsuIdAct,
                                                   UsuIdReg = p.UsuIdReg
                                               });
       
                if (usurolId != 0)
                {

                    if (usurolId == 0 && usulId == 0 && rolId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1"));
                    }
                    else if (usurolId != 0 && usulId == 0 && rolId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.UsuRolId.Equals(usurolId));
                    }
                    else if (usurolId == 0 && usulId != 0 && rolId == 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.UsuId.Equals(usulId));
                    }
                    else if (usurolId == 0 && usulId != 0 && rolId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.UsuId.Equals(usulId) && p.RolId == rolId);
                    }
                    else if (usurolId == 0 && usulId == 0 && rolId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.RolId == rolId);
                    }
                    else if (usurolId != 0 && usulId != 0 && rolId != 0)
                    {
                        query = query.Where(p => p.Estado.Equals("1") && p.UsuRolId.Equals(usurolId) && p.UsuId.Equals(usulId) && p.RolId == rolId);
                    }

                }
                respuesta.Data = await query.ToListAsync();
                respuesta.Mensaje = "OK";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioRolService", "GetUsuarioRol", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostUsuarioRol(UsuarioRol usuarioRol)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.UsuarioRols.OrderByDescending(c => c.UsuRolId).Select(c => c.UsuRolId).FirstOrDefault();

                usuarioRol.UsuRolId = Convert.ToInt32(query) + 1;
                usuarioRol.FechaHoraReg = DateTime.Now;

                _context.UsuarioRols.Add(usuarioRol);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioRolService", "PostUsuarioRol", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutUsuarioRol(UsuarioRol usuarioRol)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.UsuarioRols.Update(usuarioRol);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("UsuarioRolService", "PutUsuarioRol", ee.Message);
            }
            return respuesta;
        }

        //-------------------------------------------------------------------------------------
    }
}
