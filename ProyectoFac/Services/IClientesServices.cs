using ProyectoFac.DTOs;
using ProyectoFac.DTOs.ClientesDtos;

namespace ProyectoFac.Services
{
    public interface IClientesServices
    {
        Task<IEnumerable<ClienteDtos>> GetCliente();
        Task<ClienteDtos> GetIdcliente(int idcliente);
        Task<ClienteDtos> AddCliente(ClienteInsertDto cliente);
        Task<ClienteDtos> UpdateCliente(int idcliente, ClienteUpdateDto cliente);
        Task<ClienteDtos> DeleteCliene(int idcliente);
    }
}
