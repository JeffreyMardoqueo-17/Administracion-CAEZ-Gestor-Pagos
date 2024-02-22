using System.ComponentModel.DataAnnotations;

namespace CAEZAdministracionFrontend.Models
{
    public class Fondo
    {
        public int Id { get; set; }
        [Display(Name = "Monto Fondo")]
        public Decimal Monto { get; set; }
        
    }
}
