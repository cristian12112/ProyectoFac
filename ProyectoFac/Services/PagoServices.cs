using ProyectoFac.Context;
using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Pago;
using ProyectoFac.Interface.Pago;

namespace ProyectoFac.Services
{
    public class PagoServices : IPago
    {

        private StoreContext _context;

        public PagoServices(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PagoDtos>> ListarPagos() => 
        
        public async Task<PagoDtos> AddPAgo()
        {
            throw new NotImplementedException();
        }
        ss
        public async Task<PagoDtos> UpdatePagos(PagoUpdateDtos updatePago, int idpago)
        {
            throw new NotImplementedException();
        }
        public async Task<PagoDtos> DeletePagos(PagoDeleteDtos deletePago, int idpago)
        {
            throw new NotImplementedException();
        }
    }
}
