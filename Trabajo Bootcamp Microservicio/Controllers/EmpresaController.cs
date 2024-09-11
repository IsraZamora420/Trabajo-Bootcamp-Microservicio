using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;
using Trabajo_Bootcamp_Microservicio.DTOs;
using Trabajo_Bootcamp_Microservicio.Interfaces;
using Trabajo_Bootcamp_Microservicio.Models;
using Trabajo_Bootcamp_Microservicio.Utilities;

namespace Trabajo_Bootcamp_Microservicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresa _empresa;
        private ControlError Log = new ControlError();

        public EmpresaController(IEmpresa empresa)
        {
            this._empresa = empresa;
        }

        [HttpPost]
        [Route("GetEmpresa")]
        public async Task<Respuesta> GetEmpresa([FromBody] Request request)
        {
            var respuesta = new Respuesta();
            var empresaDto = new JsonLogDto();
            try
            {
                empresaDto = JsonConvert.DeserializeObject<JsonLogDto>(Convert.ToString(request.Data));
                respuesta = await _empresa.GetEmpresa(empresaDto.idEmpresa, empresaDto.empresaRuc, empresaDto.empresaNombre);
            }
            catch (Exception ex)
            {
                Log.LogErrorMetodos("EmpresaController", "GetEmpresa", ex.Message);
            }
            return respuesta;
        }
        [HttpPost]
        [Route("PostEmpresa")]
        public async Task<Respuesta> PostEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.PostEmpresa(empresa);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("EmpresaController", "PostEmpresa", ex.Message);
            }
            return respuesta;
        }
        [HttpPut]
        [Route("PutEmpresa")]
        public async Task<Respuesta> PutEmpresa([FromBody] Empresa empresa)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _empresa.PutEmpresa(empresa);
            }
            catch (Exception ex)
            {

                Log.LogErrorMetodos("EmpresaController", "PutEmpresa", ex.Message);
            }
            return respuesta;
        }
    }
}
