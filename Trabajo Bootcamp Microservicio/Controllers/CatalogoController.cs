using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo industria)
        {
            this._catalogo = industria;
        }
        //------------------------------------------INDUSTRIA---------------------------------------

        [HttpGet]
        [Route("GetIndustria")]
        public async Task<Respuesta> GetIndustria(int industriaId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetIndustria(industriaId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetIndustria", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostIndustria")]
        public async Task<Respuesta> PostIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostIndustria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutIndustria")]
        public async Task<Respuesta> PutIndustria([FromBody] Industrium industria)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutIndustria(industria);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutIndustria", ex.Message);
            }
            return respuesta;
        }
        //-----------------------------------MODULO-------------------------------------
        [HttpGet]
        [Route("GetModulo")]
        public async Task<Respuesta> GetModulo(int moduloId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModulo(moduloId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetModulo", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostModulo")]
        public async Task<Respuesta> PostModulo([FromBody] Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostModulo(modulo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCategoria", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutModulo")]
        public async Task<Respuesta> PutModulo(Modulo modulo)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutModulo(modulo);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutModulo", ex.Message);
            }
            return respuesta;
        }
        //-----------------------------------------------CLIENTE-----------------------------------------
        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(int clienteId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetModulo(clienteId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostCliente", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutCliente(cliente);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PutCliente", ex.Message);
            }
            return respuesta;
        }
    }
}
