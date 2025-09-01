using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.ClientesDtos;
using ProyectoFac.Services;

namespace ProyectoFac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClientesServices _clientesservices;

        public ClientesController(IClientesServices clienteservice)
        {
            _clientesservices = clienteservice;
        }

        [HttpGet]
        public Task<IEnumerable<ClienteDtos>> GetCliente() => _clientesservices.GetCliente();

        [HttpGet("{idcliente}")]
        public async Task<ActionResult<ClienteDtos>> GetIdcliente(int idcliente)
        {
            var cliente = await _clientesservices.GetIdcliente(idcliente);
            
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDtos>> AddCliente(ClienteInsertDto clienteinsert)
        {
            var clienteDto = await _clientesservices.AddCliente(clienteinsert);

            if(clienteDto == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetIdcliente), new { idcliente = clienteDto.prg_int_idcliente }, clienteDto);
        }

        [HttpPut("{idcliente}")]
        public async Task<ActionResult<ClienteDtos>> UpdateCliente(int idcliente, ClienteUpdateDto cliente)
        {
            var up = await _clientesservices.UpdateCliente(idcliente, cliente);

            return up == null ? NotFound() : Ok("se actualizo con existo");
        }

        [HttpDelete("{idcliente}")]
        public async Task<ActionResult<ClienteDtos>> DeleteCliene(int idcliente)
        {
            var clienteDelete = await _clientesservices.DeleteCliene(idcliente);
            return clienteDelete == null ? NotFound() : Ok("Se elimino con existo");
        }
    }
}
