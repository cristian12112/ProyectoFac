using ProyectoFac.DTOs;

namespace ProyectoFac.Interface
{
    public interface IEntidadFinanciera
    {
        Task<IEnumerable<EntidadFinancieraDtos>> MostrarDatos();
        Task<EntidadFinancieraDtos> AgregarDatos(EntidadFinancieraDtos add);
        Task<EntidadFinancieraDtos> UpdateEntidad(EntidadFinancieraDtos req, int identidad);
        Task<EntidadFinancieraDtos> DeleteEntidad(int identidad);
    }
}
