using System.Collections.Generic;

namespace SistemaExpedientesAcademicos.Models
{
    public class Alumno
    {
        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Grado { get; set; }
        public virtual ICollection<Expedientes> Expedientes { get; set; }
    }
}