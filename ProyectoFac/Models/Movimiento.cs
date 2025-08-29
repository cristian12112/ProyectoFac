using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idmovimiento { get; set; }

        public int prg_int_idusuario { get; set; }
        public int? prg_int_idfactura { get; set; }
        public int? prg_int_idcontrato { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string prg_vch_accion { get; set; }

        [Column(TypeName = "text")]
        public string prg_txt_descripcion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime prg_dt_fecha { get; set; } = DateTime.Now;
    }
}
