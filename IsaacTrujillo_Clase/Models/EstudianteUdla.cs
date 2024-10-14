using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace IsaacTrujillo_Clase.Models
{
    public class EstudianteUdla
    {
        [Key]
        public int IdBanner { get; set; }
        [MaxLength(200)]
        [Required]
        public int Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [EmailAddress]
        [AllowNull]
        public string correo { get; set; }
        public bool TieneBeca { get; set; }
        public Carrera carrea { get; set; }
        [ForeignKey("Carrera")]
        public int IdCarrera {  get; set; }
         
    }
}
