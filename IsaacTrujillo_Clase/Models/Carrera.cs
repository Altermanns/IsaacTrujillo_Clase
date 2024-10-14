using System.ComponentModel.DataAnnotations;

namespace IsaacTrujillo_Clase.Models
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
