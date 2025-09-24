using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs.Movimiento
{
    public class MovimientoUpdateDtos
    {
        public string Accion { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
