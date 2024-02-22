namespace CAEZAdministracionFrontend.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int IdGrado { get; set; }
        public int IdTipoDoc {  get; set; }
        public string NumeroDocumento {  get; set; } = string.Empty;
        public int IdEncargado {  get; set; }
        public int IdTurno { get; set; }
        public int IdAministrador { get; set; }


        public Grado Grado { get; set; } = new Grado();
        public TipoDocumento TipoDocumento { get; set; } = new TipoDocumento();
        public Encargado Encargado { get; set; } = new Encargado();
        public Turno Turno { get; set; } = new Turno();
        public Administrador Administrador { get; set; } = new Administrador();
    }
}
