namespace SistemaExpedientesAcademicos.Models
{
    public class PromedioAlumnoViewModel
    {
        public int AlumnoId { get; set; }
        public string NombreCompleto { get; set; }
        public string Grado { get; set; }
        public decimal PromedioNotas { get; set; }
        public int CantidadMaterias { get; set; }
    }
}