using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFac.DTOs
{
    public class PagoDtos
    {
        public int prg_int_idpago { get; set; }

        public int prg_int_idcontrato { get; set; }

        public DateTime prg_dt_fechapago { get; set; }

        public decimal prg_dec_montopagado { get; set; }

        public string prg_vch_metodopago { get; set; } = "transferencia";

        public string prg_txt_observacion { get; set; }
    }
}
