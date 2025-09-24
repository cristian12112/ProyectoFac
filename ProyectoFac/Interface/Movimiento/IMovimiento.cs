using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Movimiento;

namespace ProyectoFac.Interface.Movimiento
{
    public interface IMovimiento
    {
        Task<IEnumerable<MovimientosDtos>> ListarMovimientos();
        Task<MovimientosDtos> AddMovimiento(MovimientoAddDtos add);
        Task<MovimientosDtos> UpdateMovimiento(MovimientoUpdateDtos update, int idmovimiento);
        Task<MovimientosDtos> DeleteMovimiento(int idmovimiento);
    }
}
