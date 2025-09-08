using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Factura;

namespace ProyectoFac.Interface.Factura
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDtos>> Facturas();
        Task<FacturaDtos> AddFacturas(FacturaAddDtos facturadto);
        Task<FacturaDtos> UpdateFacturas(FacturaUpdateDtos facturadto, int factura);
        Task<FacturaDtos> DeleteFacturas(int factura);
    }
}
