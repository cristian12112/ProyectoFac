using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class ContratoFactoring
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idcontrato { get; set; }

        public int prg_int_idfactura { get; set; }
        public int prg_int_identidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime prg_dt_fechacesion { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal prg_dec_montocedido { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal prg_dec_tasainteres { get; set; }

        public int prg_int_plazodias { get; set; }

        [Column(TypeName = "enum('activo','finalizado','cancelado')")]
        public string prg_vch_estado { get; set; } = "activo";
    }
}
