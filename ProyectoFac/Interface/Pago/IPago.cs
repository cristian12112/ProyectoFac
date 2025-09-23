using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Pago;

namespace ProyectoFac.Interface.Pago
{
    public interface IPago
    {
        Task<IEnumerable<PagoDtos>> ListarPagos();
        Task<PagoDtos> AddPago(PagoAddDtos add);
        Task<PagoDtos> UpdatePagos(PagoUpdateDtos updatePago, int idpago);
        Task<PagoDtos> DeletePagos(int idpago);
    }
}
