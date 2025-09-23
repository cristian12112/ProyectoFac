using ProyectoFac.DTOs;
using ProyectoFac.DTOs.Garantia;

namespace ProyectoFac.Interface.Garantia
{
    public interface IGarantias
    {
        Task<IEnumerable<GarantiasDto>> ListarGarantia();
        Task<GarantiasDto> AddGarantia(GarantiaAddDtos add);
        Task<GarantiasDto> UpdateGarantia(GarantiaUpdateDtos update, int idgarantia);
        Task<GarantiasDto> DeleteGarantia(int idgarantia);
    }
}
