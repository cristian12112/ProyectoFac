using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs
{
    public class EntidadFinancieraDtos
    {
        public int    IdEntidad { get; set; }
        public string Nombre    { get; set; }
        public string RUT       { get; set; }
        public string Direccion { get; set; }
        public string Telefono  { get; set; }
        public string Email     { get; set; }
    }
}
