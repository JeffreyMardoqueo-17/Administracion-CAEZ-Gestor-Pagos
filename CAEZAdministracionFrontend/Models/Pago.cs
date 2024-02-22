using System.ComponentModel.DataAnnotations;

namespace CAEZAdministracionFrontend.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public int IdAlumno { get; set; } 
        public int IdEncargado { get; set; }
        [Display(Name = "Monto Pago")]
        public Decimal Monto { get; set;  }
        public Decimal Multa { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdAdministrador { get; set; }

        public Alumno Alumno { get; set; } = new Alumno();
        public Encargado Encargado { get; set; } = new Encargado();
        public Administrador Administrador { get; set; } = new Administrador();
    }
}
