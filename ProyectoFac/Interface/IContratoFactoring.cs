using ProyectoFac.DTOs;

namespace ProyectoFac.Interface
{
    public interface IContratoFactoring
    {
        Task<IEnumerable<ContratoFacturaDTOs>> ListarContrato();
        Task<ContratoFacturaDTOs> AddContrato(ContratoFacturaDTOs add);
        Task<ContratoFacturaDTOs> UpdateContrato(ContratoFacturaDTOs update, int idcontrato);
        Task<ContratoFacturaDTOs> DeleteContrato(int idcontrato);
    }
}
