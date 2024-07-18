using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Utilities;
using Trabajo_Bootcamp_Microservicio.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class CatalogoServices: ICatalogo
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();
        public CatalogoServices(BaseErpContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetRol()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Rols.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetRol", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> GetProveedor()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Proveedors.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetProveedor", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostProveedor(Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Proveedors.OrderByDescending(c => c.ProvId).Select(c => c.ProvId).FirstOrDefault();

                proveedor.ProvId = Convert.ToInt32(query) + 1;
                //vendedor.FechaHoraReg = DateTime.Now;

                _context.Proveedors.Add(proveedor);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostProveedor", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutProveedor(Proveedor proveedor)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Proveedors.Update(proveedor);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PutProveedor", ee.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostRol(Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Rols.OrderByDescending(c => c.RolId).Select(c => c.RolId).FirstOrDefault();

                rol.RolId = Convert.ToInt32(query) + 1;
                rol.FechaHoraReg = DateTime.Now;

                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostRol", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutRol(Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Rols.Update(rol);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PutRol", ee.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetTipoMovimiento()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.TipoMovimientos.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetTipoMovimientos", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PostTipoMovimiento(TipoMovimiento tipoMovimiento)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.TipoMovimientos.OrderByDescending(c => c.TipomovId).Select(c => c.TipomovId).FirstOrDefault();

                tipoMovimiento.TipomovId = Convert.ToInt32(query) + 1;
                tipoMovimiento.FechaHoraReg = DateTime.Now;

                _context.TipoMovimientos.Add(tipoMovimiento);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostTipoMovimiento", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutTipoMovimiento(TipoMovimiento tipoMovimiento)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.TipoMovimientos.Update(tipoMovimiento);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PutTipoMovimiento", ee.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetUsuario()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                respuesta.Data = await _context.Usuarios.ToListAsync();
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetUsuarios", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PostUsuario(Usuario usuario)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Usuarios.OrderByDescending(c => c.UsuId).Select(c => c.UsuId).FirstOrDefault();

                usuario.UsuId = Convert.ToInt32(query) + 1;
                usuario.FechaHoraReg = DateTime.Now;

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostUsuarios", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutUsuario(Usuario usuario)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ee)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PutUsuarios", ee.Message);
            }
            return respuesta;
        }


    }
}
