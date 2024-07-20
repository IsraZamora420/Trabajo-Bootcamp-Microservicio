using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CiudadController : Controller
    {
        private readonly ICiudad _ciudad;
        private ControlError Log = new ControlError();
        public CiudadController(ICiudad ciudad)
        {
            this._ciudad = ciudad;
        }
        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad(int ciudadId, string? nombreCiudad, int paisId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.GetCiudad(ciudadId, nombreCiudad, paisId);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "GetCiudad", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostCiudad")]
        public async Task<Respuesta> PostCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.PostCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "PostCiudad", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutCiudad")]
        public async Task<Respuesta> PutCiudad([FromBody] Ciudad ciudad)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _ciudad.PutCiudad(ciudad);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CiudadController", "PutCiudad", ex.Message);
            }
            return respuesta;
        }
        //----------------------------------------------------------------------------------------------

    }
}
