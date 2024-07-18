using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Route("[Maestros]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogo _catalogo;
        private ControlError Log = new ControlError();
        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }

        [HttpGet]
        [Route("GetRol")]
        public async Task<Respuesta> GetRol()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetRol();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetRol", ex.Message);
            }
            return respuesta;
        }
        [HttpGet]
        [Route("GetProveedor")]
        public async Task<Respuesta> GetProveedor()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.GetProveedor();
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("CatalogoController", "GetProveedor", ex.Message);
            }
            return respuesta;
        }


        [HttpPost]
        [Route("PostRol")]
        public async Task<Respuesta> PostRol([FromBody] Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PostRol(rol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("RolController", "PostRol", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutRol")]
        public async Task<Respuesta> PutRol([FromBody] Rol rol)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _catalogo.PutRol(rol);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("PaisController", "PutRol", ex.Message);
            }
            return respuesta;
        }


    }
}
