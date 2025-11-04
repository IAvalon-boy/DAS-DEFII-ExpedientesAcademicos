using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaExpedientesAcademicos.Models
{
    public class Materias
    {
        [Key]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [Display(Name = "Nombre de la Materia")]
        [StringLength(100)]
        public string NombreMateria { get; set; }

        [Required(ErrorMessage = "El docente es obligatorio")]
        [StringLength(100)]
        public string Docente { get; set; }

        // Navigation property
        public virtual ICollection<Expedientes> Expedientes { get; set; }
    }
}