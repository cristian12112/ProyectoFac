using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Factura;
using ProyectoFac.DTOs.Pago;
using ProyectoFac.Interface.Factura;
using ProyectoFac.Interface.Pago;
using ProyectoFac.Services;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        private IPago _pagoServices;

        public PagoController(IPago pagoServices)
        {
            _pagoServices = pagoServices;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPagos()
        {
            var pagos = await _pagoServices.ListarPagos();
            return Ok(pagos);
        }

        [HttpDelete]
        [Route("[action]/pagos")]
        public async Task<ActionResult<PagoServices>> DeletePagos(int pagos)
        {
            var delete = await _pagoServices.DeletePagos(pagos);
            return delete == null ? NotFound() : Ok("Se elimino con existo");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<PagoServices>> AddPago(PagoAddDtos req)
        {
            var response = await _pagoServices.AddPago(req);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("[action]/idpago")]
        public async Task<ActionResult<PagoServices>> UpdateFacturas(PagoUpdateDtos pagos, int idpago)
        {
            var response = await _pagoServices.UpdatePagos(pagos, idpago);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }

    }
}
