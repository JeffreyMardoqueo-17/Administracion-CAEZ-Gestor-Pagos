namespace CAEZAdministracionFrontend.Models
{
    public class Encargado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido {  get; set; } = string.Empty;
        public int IdTipoDoc { get; set; }
        public int NumeroDocumento { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Parentezco { get; set; } = string.Empty;
        public int IdAministrador { get; set; }

        public Administrador Administrador { get; set; } = new Administrador();
        public TipoDocumento TipoDocumento { get; set; } = new TipoDocumento();
    }
}
