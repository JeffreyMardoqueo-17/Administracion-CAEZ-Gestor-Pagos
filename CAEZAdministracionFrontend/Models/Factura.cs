namespace CAEZAdministracionFrontend.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public int IdPago { get; set; }  

        public Pago Pago { get; set; } = new Pago();
    }
}
