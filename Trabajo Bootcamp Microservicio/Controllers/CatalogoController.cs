using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();

        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetPais")]
        public async Task<Respuesta> GetPais(int idpais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetPais(idpais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetPais", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostPais")]
        public async Task<Respuesta> PostPais([FromBody] Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "PostPais", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutPais")]
        public async Task<Respuesta> PutPais([FromBody] Pai pais)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutPais", ex.Message);
            }
            return respuesta;
        }
    }
}
