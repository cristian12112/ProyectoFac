using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Factura;
using ProyectoFac.Interface.Factura;
using ProyectoFac.Models;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaService _facturaservice;

        public FacturaController(IFacturaService facturaservice)
        {
            _facturaservice = facturaservice;
        }

        [HttpGet]
        public Task<IEnumerable<FacturaDtos>> Facturas() => _facturaservice.Facturas();

        [HttpDelete]
        [Route("[action]/factura")]
        public async Task<ActionResult<FacturaDtos>> DeleteFacturas(int factura)
        {
            var delete = await _facturaservice.DeleteFacturas(factura);
            return delete == null ? NotFound() : Ok("Se elimino con existo");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<FacturaDtos>> AddFacturas(FacturaAddDtos req)
        {
            var response = await _facturaservice.AddFacturas(req);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [Route("[action]/idfactura")]
        public async Task<ActionResult<FacturaDtos>> UpdateFacturas(FacturaUpdateDtos facturadto, int idfactura)
        {
            var response = await _facturaservice.UpdateFacturas(facturadto, idfactura);
            return response == null ? NotFound() : Ok("se actualizo con existo");
        }


    }
}
