using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs
{
    public class ContratoFacturaDTOs
    {
        public int Idcontrato { get; set; }
        public int Idfactura { get; set; }
        public int Identidad { get; set; }

        public DateTime Fechacesion { get; set; }

        public decimal Montocedido { get; set; }

        public decimal Tasainteres { get; set; }

        public int Plazodias { get; set; }

        public string Estado { get; set; } = "activo";
    }
}
