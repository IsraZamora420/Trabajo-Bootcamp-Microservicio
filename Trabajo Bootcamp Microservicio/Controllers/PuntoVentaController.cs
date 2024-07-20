using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuntoVentaController : Controller
    {
        private readonly IPuntoVenta _puntoVenta;
        private ControlError Log = new ControlError();

        public PuntoVentaController(IPuntoVenta puntoVenta)
        {
            this._puntoVenta = puntoVenta;
        }

        [HttpGet]
        [Route("GetPuntoEmisionSRI")]
        public async Task<Respuesta> GetPuntoEmisionSRI(int PuntoEmisionId, string? PuntoEmision, int? EmpresaId, int? SucursalId, string? CodEstablecimientoSri)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.GetPuntoEmisionSRI(PuntoEmisionId, PuntoEmision, EmpresaId, SucursalId, CodEstablecimientoSri);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "GetPuntoEmisionSRI", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetPuntoVenta")]
        public async Task<Respuesta> GetPuntoVenta(int PuntovtaId, string? PuntovtaNombre, int? PuntoEmisionId)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.GetPuntoVenta(PuntovtaId, PuntovtaNombre, PuntoEmisionId);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "GetPuntoVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostPuntoEmisionSRI")]
        public async Task<Respuesta> PostPuntoEmisionSRI([FromBody] PuntoEmisionSri puntoSRI)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.PostPuntoEmisionSRI(puntoSRI);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "PostPuntoEmisionSRI", ex.Message);
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PostPuntoVenta")]
        public async Task<Respuesta> PostPuntoVenta([FromBody] PuntoVentum puntoVenta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.PostPuntoVenta(puntoVenta);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "PostPuntoVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutPuntoEmisionSRI")]
        public async Task<Respuesta> PutPuntoEmisionSRI([FromBody] PuntoEmisionSri puntoSRI)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.PutPuntoEmisionSRI(puntoSRI);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "PostPuntoVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpPut]
        [Route("PutPuntoVenta")]
        public async Task<Respuesta> PutPuntoVenta([FromBody] PuntoVentum puntoVenta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _puntoVenta.PutPuntoVenta(puntoVenta);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("PuntoVentaController", "PutPuntoVenta", ex.Message);
            }
            return respuesta;
        }

    }
}
