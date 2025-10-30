using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Movimiento;
using ProyectoFac.Interface.Movimiento;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientroController : ControllerBase
    {
        private IMovimiento _movimiento;

        public MovimientroController(IMovimiento movimiento)
        {
            _movimiento = movimiento;
        }

        [HttpGet]
        [Route("[action]")]
        public Task<IEnumerable<MovimientosDtos>> ListarMovimientos() => _movimiento.ListarMovimientos();

        [HttpDelete]
        [Route("[action]/{idmovimiento}")]
        public async Task<ActionResult<MovimientosDtos>> DeleteMovimiento(int idmovimiento)
        {
            var delete = await _movimiento.DeleteMovimiento(idmovimiento);
            return delete == null ? NotFound() : Ok("Se elimino con existo");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<MovimientoAddDtos>> AddMovimiento(MovimientoAddDtos add)
        {
            var response = await _movimiento.AddMovimiento(add);
            return response == null ? NotFound() : Ok();
        }

        [HttpPut]
        [Route("[action]/{idmovimiento}")]
        public async Task<ActionResult<MovimientosDtos>> UpdateMovimiento(MovimientoUpdateDtos update, int idmovimiento)
        {
            var response = await _movimiento.UpdateMovimiento(update, idmovimiento);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }

    }
}
