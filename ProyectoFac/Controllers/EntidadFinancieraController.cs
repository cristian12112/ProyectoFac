using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.Interface;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntidadFinancieraController : ControllerBase
    {
        private IEntidadFinanciera _entidadF;

        public EntidadFinancieraController(IEntidadFinanciera entidadF)
        {
            _entidadF = entidadF;
        }

        [HttpGet]
        public async Task<IEnumerable<EntidadFinancieraDtos>> MostrarDatos() => await _entidadF.MostrarDatos();

        [HttpDelete]
        [Route("{identidad}")]
        public async Task<ActionResult<EntidadFinancieraDtos>> DeleteEntidad(int identidad)
        {
            var req = await _entidadF.DeleteEntidad(identidad);
            return req == null ? NotFound() : Ok("Se elimino con existo");
        }

        [HttpPut]
        [Route("{identidad}")]
        public async Task<ActionResult<EntidadFinancieraDtos>> UpdateEntidad(EntidadFinancieraDtos req, int identidad)
        {
            var response = await _entidadF.UpdateEntidad(req, identidad);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }

        [HttpPost]
        public async Task<ActionResult<EntidadFinancieraDtos>> AgregarDatos(EntidadFinancieraDtos req)
        {
            var response = await _entidadF.AgregarDatos(req);
            return response == null ? NotFound() : Ok();
        }

    }
}
