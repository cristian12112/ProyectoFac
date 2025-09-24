using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.Interface;
using ProyectoFac.Models;

namespace ProyectoFac.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
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
    }
}
