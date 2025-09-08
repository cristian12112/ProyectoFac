namespace ProyectoFac.DTOs.Factura
{
    public class FacturaAddDtos
    {
        public int prg_int_idcliente { get; set; }

        public string prg_vch_numerofactura { get; set; }

        public DateTime prg_dt_fechaemision { get; set; }

        public DateTime prg_dt_fechavencimiento { get; set; }

        public decimal prg_dec_monto { get; set; }

        public string prg_vch_moneda { get; set; } = "PEN";

        public string prg_vch_estado { get; set; } = "pendiente";

        public string prg_txt_descripcion { get; set; }
    }
}
