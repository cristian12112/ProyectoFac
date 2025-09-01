using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int      prg_int_idcliente   { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string   prg_vch_nombre      { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string   prg_vch_rut         { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string   prg_vch_direccion   { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string   prg_vch_telefono    { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string   prg_vch_email       { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string    prg_int_tipo       { get; set; }
        [DataType(DataType.Date)]
        public DateTime prg_dt_fecharegistro{ get; set; } = DateTime.Now;


    }
}
