using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExpedientesAcademicos.Models
{
    public class Expedientes
    {
        [Key]
        public int ExpedienteId { get; set; }

        [Required(ErrorMessage = "El alumno es obligatorio")]
        [Display(Name = "Alumno")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "La materia es obligatoria")]
        [Display(Name = "Materia")]
        public int MateriaId { get; set; }

        [Required(ErrorMessage = "La nota final es obligatoria")]
        [Display(Name = "Nota Final")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        public decimal NotaFinal { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(500)]
        public string Observaciones { get; set; }

        // Navigation properties
        [ForeignKey("AlumnoId")]
        public virtual Alumno Alumno { get; set; }

        [ForeignKey("MateriaId")]
        public virtual Materias Materia { get; set; }
    }
}