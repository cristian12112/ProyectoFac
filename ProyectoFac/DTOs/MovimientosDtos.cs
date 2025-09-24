namespace ProyectoFac.DTOs
{
    public class MovimientosDtos
    {
        public int Idmovimiento { get; set; }

        public int Idusuario { get; set; }

        public int? Idfactura { get; set; }

        public int? Idcontrato { get; set; }

        public string Accion { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
