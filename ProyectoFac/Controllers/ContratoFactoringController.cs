using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.Interface;
using ProyectoFac.Models;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/contratofactoring[controller]")]
    [ApiController]
    public class ContratoFactoringController : ControllerBase
    {
        private IContratoFactoring _contratoFactoring;

        public ContratoFactoringController(IContratoFactoring contratoFactoring)
        {
            _contratoFactoring = contratoFactoring;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<IEnumerable<ContratoFacturaDTOs>> ListarContratoFactoring() => _contratoFactoring.ListarContrato();

        [HttpDelete]
        [Route("[action]/{idcontrato}")]
        public async Task<ActionResult<ContratoFacturaDTOs>> DeleteContratoFactoring(int idcontrato)
        {
            var delete = await _contratoFactoring.DeleteContrato(idcontrato);
            return delete == null ? NotFound() : Ok("Se elimino con existo");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ContratoFacturaDTOs>> AddContratoFactoring(ContratoFacturaDTOs add)
        {
            var response = await _contratoFactoring.AddContrato(add);
            return response == null ? NotFound() : Ok();
        }

        [HttpPut]
        [Route("[action]/{idcontrato}")]
        public async Task<ActionResult<ContratoFacturaDTOs>> UpdateContratoFactoring(ContratoFacturaDTOs update, int idcontrato)
        {
            var response = await _contratoFactoring.UpdateContrato(update, idcontrato);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }
    }
}
