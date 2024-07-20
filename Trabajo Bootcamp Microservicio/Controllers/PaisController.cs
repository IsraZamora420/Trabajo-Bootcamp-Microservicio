using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : Controller
    {
        private readonly IPais _pais;
        private ControlError Log = new ControlError();

        public PaisController(IPais pais)
        {
            this._pais = pais;
        }

        [HttpGet]
        [Route("GetPais")]
        public async Task<Respuesta> GetPais()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _pais.GetPais();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisService", "GetPais", ex.Message);
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
                respuesta = await _pais.PostPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PostPais", ex.Message);
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
                respuesta = await _pais.PutPais(pais);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutPais", ex.Message);
            }
            return respuesta;
        }

    }
}

