using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs
{
    public class ClienteDtos
    {
        public int prg_int_idcliente { get; set; }
        public string prg_vch_nombre { get; set; }
        public string prg_vch_rut { get; set; }
        public string prg_vch_direccion { get; set; }
        public string prg_vch_telefono { get; set; }
        public string prg_vch_email { get; set; }
        public string prg_int_tipo { get; set; }
        public DateTime prg_dt_fecharegistro { get; set; } = DateTime.Now;
    }
}
