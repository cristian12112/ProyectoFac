using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs
{
    public class GarantiasDto
    {

        public int prg_int_idcliente { get; set; }

        public string prg_vch_tipo { get; set; }

        public string prg_txt_descripcion { get; set; }

        public decimal? prg_dec_valorestimado { get; set; }

        public DateTime prg_dt_fecharegistro { get; set; } = DateTime.Now;
    }
}
