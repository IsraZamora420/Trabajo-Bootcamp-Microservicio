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
