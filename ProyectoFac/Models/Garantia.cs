using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Garantia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idgarantia { get; set; }

        public int prg_int_idcliente { get; set; }

        [Column(TypeName = "enum('hipoteca','prenda','aval','fianza')")]
        public string prg_vch_tipo { get; set; }

        [Column(TypeName = "text")]
        public string prg_txt_descripcion { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? prg_dec_valorestimado { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime prg_dt_fecharegistro { get; set; } = DateTime.Now;
    }
}
