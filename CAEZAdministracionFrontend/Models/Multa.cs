namespace CAEZAdministracionFrontend.Models
{
    public class Multa
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int IdPago { get; set; }

        public Pago Pago { get; set; } = new Pago();
    }
}
