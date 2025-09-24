using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
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

    }
}
