using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_idusuario { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string prg_vch_nombreusuario { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string prg_vch_clave { get; set; }

        [Column(TypeName = "enum('administrador','analista','cobranzas')")]
        public string prg_vch_rol { get; set; } = "analista";

        public string prg_int_estado { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime prg_dt_fechacreacion { get; set; } = DateTime.Now;
    }
}
