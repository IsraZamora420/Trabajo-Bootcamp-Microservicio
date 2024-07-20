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
    }
}

   
