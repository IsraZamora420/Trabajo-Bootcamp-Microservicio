using Microsoft.AspNetCore.Mvc;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SucursalController : Controller
    {
        private readonly ISucursal _sucursal;
        private ControlError Log = new ControlError();

        public SucursalController(ISucursal sucursal)
        {
            this._sucursal = sucursal;
        }

        [HttpGet]
        [Route("GetSucursal")]
        public async Task<Respuesta> GetSucursal(int SucursalId, string? SucursalRuc, string? SucursalNombre)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _sucursal.GetSucursal(SucursalId, SucursalRuc, SucursalNombre);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("SucursalController", "GetSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostSucursal")]
        public async Task<Respuesta> PostSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _sucursal.PostSucursal(sucursal);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("SucursalController", "PostSucursal", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutSucursal")]
        public async Task<Respuesta> PutSucursal([FromBody] Sucursal sucursal)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _sucursal.PutSucursal(sucursal);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("SucursalController", "PutSucursal", ex.Message);
            }
            return respuesta;
        }
    }
}
