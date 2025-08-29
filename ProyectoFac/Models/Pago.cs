using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idpago { get; set; }

        public int prg_int_idcontrato { get; set; }

        [DataType(DataType.Date)]
        public DateTime prg_dt_fechapago { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal prg_dec_montopagado { get; set; }

        [Column(TypeName = "enum('transferencia','efectivo','cheque')")]
        public string prg_vch_metodopago { get; set; } = "transferencia";

        [Column(TypeName = "text")]
        public string prg_txt_observacion { get; set; }
    }
}
