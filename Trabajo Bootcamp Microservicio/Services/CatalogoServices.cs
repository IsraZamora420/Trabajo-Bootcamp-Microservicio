using Microsoft.EntityFrameworkCore;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Services
{
    public class CatalogoServices : ICatalogo
    {
        private readonly BaseErpContext _context;
        private ControlError Log = new ControlError();

        public CatalogoServices(BaseErpContext context)
        {
            this._context = context;
        }

        //------------------------------------------INDUSTRIA------------------------------------------------------------------------------
        public async Task<Respuesta> GetIndustria(int industriaId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (industriaId == 0)
                {
                    respuesta.Data = await _context.Industria.ToListAsync();
                }
                else if (industriaId != 0)
                {
                    respuesta.Data = await _context.Industria.Where(i => i.IndustriaId.Equals(industriaId)).ToListAsync();
                }
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetIndustria", ex.Message);
            }

            return respuesta;
        }
        public async Task<Respuesta> PostIndustria(Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Industria.OrderByDescending(x => x.IndustriaId).Select(x => x.IndustriaId).FirstOrDefault();

                {

                    industria.IndustriaId = Convert.ToInt32(query) + 1;
                    industria.FechaHoraReg = DateTime.Now;
                    industria.FechaHoraAct = DateTime.Now;

                    _context.Industria.Add(industria);
                    await _context.SaveChangesAsync();

                    respuesta.Cod = "000";
                    respuesta.Mensaje = "Se insertó correctamente";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "PostIndustria", ex.Message);
            }
            return respuesta;
        }
        public async Task<Respuesta> PutIndustria(Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                industria.FechaHoraAct = DateTime.Now;
                _context.Industria.Update(industria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutPais", ex.Message);
            }
            return respuesta;
        }

        //-------------------------------------------MODULO-----------------------------------------------------------

        public async Task<Respuesta> GetModulo(int moduloId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (moduloId == 0)
                {
                    respuesta.Data = await _context.Modulos.ToListAsync();
                }
                else if (moduloId != 0)
                {
                    respuesta.Data = await _context.Modulos.Where(m => m.ModuloId == moduloId).ToListAsync();
                }
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "GetModulo", ex.Message);
            }

            return respuesta;
        }
        public async Task<Respuesta> PutModulo(Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                modulo.FechaHoraAct = DateTime.Now;
                _context.Modulos.Update(modulo);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutModulo", ex.Message);

            }
            return respuesta;
        }
        public async Task<Respuesta> PostModulo(Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Modulos.OrderByDescending(m => m.ModuloId).Select(x => x.ModuloId).FirstOrDefault();

                modulo.ModuloId = Convert.ToInt32(query) + 1;
                modulo.FechaHoraReg = DateTime.Now;
                modulo.FechaHoraAct = DateTime.Now;

                _context.Modulos.Add(modulo);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PostModulo", ex.Message);
            }
            return respuesta;
        }


        //---------------------------------------------CLIENTE-----------------------------------------------
        public async Task<Respuesta> GetCliente(int clienteId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (clienteId == 0)
                {
                    respuesta.Data = await _context.Clientes.ToListAsync();
                }
                else if (clienteId != 0)
                {
                    respuesta.Data = await _context.Clientes.Where(c => c.ClienteId == clienteId).ToListAsync();
                }
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
            }

            return respuesta;
        }
        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();

            try
            {
                var query = _context.Clientes.OrderByDescending(c => c.ClienteId).Select(c => c.ClienteId).FirstOrDefault();

                cliente.ClienteId = Convert.ToInt32(query) + 1;
                cliente.FechaHoraReg = DateTime.Now;
                var FechaCompleta = DateTime.Now;
                cliente.FechaHoraAct = DateOnly.FromDateTime(FechaCompleta);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";

            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad -> {ex}, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PostCliente", ex.Message);

            }
            return respuesta;
        }
        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                var FechaCompleta = DateTime.Now;
                cliente.FechaHoraAct = DateOnly.FromDateTime(FechaCompleta);
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutCliente", ex.Message);
            }
            return respuesta;
        }

        //-----------------------------------------------ROL--------------------------------------
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

        //-------------------------------------------------------------------------------------

        //-----------------------------------------------TIPO MOVIMIENTO--------------------------------------
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
        //-------------------------------------------------------------------------------------

        //-----------------------------------------------USUARIO--------------------------------------
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
                usuario.FechaHoraReg = Convert.ToString(DateTime.Now);

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
        //-------------------------------------------------------------------------------------
        //-----------------------------------------------PAIS--------------------------------------
        public async Task<Respuesta> GetPais(int idpais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (idpais == 0)
                {
                    respuesta.Data = await _context.Pais.ToListAsync();
                }
                else if (idpais != 0)
                {
                    respuesta.Data = await _context.Pais.Where(p => p.PaisId.Equals(idpais)).ToListAsync();
                }
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoService", "GetPais", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostPais(Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Pais.OrderByDescending(x => x.PaisId).Select(x => x.PaisId).FirstOrDefault();

                pais.PaisId = Convert.ToInt32(query) + 1;
                pais.FechaHoraReg = DateTime.Now;
                pais.FechaHoraAct = DateTime.Now;

                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PostPais", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutPais(Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                pais.FechaHoraAct = DateTime.Now;
                _context.Pais.Update(pais);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutPais", ex.Message);
            }
            return respuesta;
        }
        //-------------------------------------------------------------------------------------------------
        /*
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
        */

        //-----------------------------------------------CATEGORIA--------------------------------------------
        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Categoria.OrderByDescending(x => x.CategoriaId).Select(x => x.CategoriaId).FirstOrDefault();

                categoria.CategoriaId = Convert.ToInt32(query) + 1;
                categoria.FechaHoraReg = DateTime.Now;
                categoria.FechaHoraAct = DateTime.Now;

                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetCategoria(int idCategoria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (idCategoria == 0)
                {
                    respuesta.Data = await _context.Categoria.ToListAsync();
                }
                else if (idCategoria != 0)
                {
                    respuesta.Data = await _context.Categoria.Where(p => p.CategoriaId == idCategoria).ToListAsync();
                }
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "GetCategoria", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutCategoria(Categorium categoria)
        {
            var respuesta = new Respuesta();
            try
            {
                categoria.FechaHoraAct = DateTime.Now;
                _context.Categoria.Update(categoria);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutCategoria", ex.Message);
            }
            return respuesta;
        }
        //--------------------------------------------------------------------------------------------------------
        //-----------------------------------------------FORMA DE PAGO--------------------------------------------
        public async Task<Respuesta> GetFormaPago(int idPago)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";
                if (idPago == 0)
                {
                    respuesta.Data = await _context.FormaPagos.ToListAsync();
                }
                else if (idPago != 0)
                {
                    respuesta.Data = await _context.FormaPagos.Where(p => p.FpagoId == idPago).ToListAsync();
                }
                respuesta.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "GetFormaPago", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PostFormaPago(FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.FormaPagos.OrderByDescending(x => x.FpagoId).Select(x => x.FpagoId).FirstOrDefault();

                formaPago.FpagoId = Convert.ToInt32(query) + 1;
                formaPago.FechaHoraReg = DateTime.Now;
                formaPago.FechaHoraAct = DateTime.Now;

                _context.FormaPagos.Add(formaPago);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se insertó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PostFormaPago", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> PutFormaPago(FormaPago formaPago)
        {
            var respuesta = new Respuesta();
            try
            {
                formaPago.FechaHoraAct = DateTime.Now;
                _context.FormaPagos.Update(formaPago);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "000";
                respuesta.Mensaje = $"Se presentó una novedad, comunicarse con el administrador del sistema";
                Log.LogErrorMetodos("CatalogoServices", "PutFormaPago", ex.Message);
            }
            return respuesta;
        }
    }
}


