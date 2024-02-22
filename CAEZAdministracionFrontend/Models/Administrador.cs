namespace CAEZAdministracionFrontend.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido {  get; set; } = string.Empty;
        public int IdCargo { get; set; }
        public int Telefono { get; set; }
        public int Pass {  get; set; }

        public Cargo Cargo { get; set; } = new Cargo();
    }
}
