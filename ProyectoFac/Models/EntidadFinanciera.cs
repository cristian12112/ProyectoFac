using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class EntidadFinanciera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prg_int_identidad { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string prg_vch_nombre { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string prg_vch_ruc { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string prg_vch_direccion { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string prg_vch_telefono { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string prg_vch_email { get; set; }
    }
}
