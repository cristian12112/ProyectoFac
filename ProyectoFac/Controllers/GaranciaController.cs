using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Factura;
using ProyectoFac.DTOs.Garantia;
using ProyectoFac.Interface.Garantia;
using ProyectoFac.Models;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GaranciaController : ControllerBase
    {
        private IGarantias _garantias;

        public GaranciaController(IGarantias garantias)
        {
            _garantias = garantias;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<IEnumerable<GarantiasDto>> ListarGarantia() => _garantias.ListarGarantia();

        [HttpDelete]
        [Route("[action]/idgarantia")]
        public async Task<ActionResult<GarantiasDto>> DeleteGarantia(int idgarantia)
        {
            var delete = await _garantias.DeleteGarantia(idgarantia);
            return delete == null ? NotFound() : Ok("Se elimino con existo");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<GarantiasDto>> AddGarantia(GarantiaAddDtos req)
        {
            var response = await _garantias.AddGarantia(req);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("[action]/idgarantia")]
        public async Task<ActionResult<GarantiasDto>> UpdateGarantia(GarantiaUpdateDtos update, int idgarantia)
        {
            var response = await _garantias.UpdateGarantia(update, idgarantia);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }
    }
}
