using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idfactura { get; set; }

        public int prg_int_idcliente { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string prg_vch_numerofactura { get; set; }

        [DataType(DataType.Date)]
        public DateTime prg_dt_fechaemision { get; set; }

        [DataType(DataType.Date)]
        public DateTime prg_dt_fechavencimiento { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal prg_dec_monto { get; set; }

        [Column(TypeName = "enum('PEN','USD','EUR')")]
        public string prg_vch_moneda { get; set; } = "PEN";

        [Column(TypeName = "enum('pendiente','cedida','pagada','vencida')")]
        public string prg_vch_estado { get; set; } = "pendiente";

        [Column(TypeName = "text")]
        public string prg_txt_descripcion { get; set; }
    }
}
