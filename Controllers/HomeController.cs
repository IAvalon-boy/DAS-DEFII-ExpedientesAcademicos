using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaExpedientesAcademicos.Data;
using SistemaExpedientesAcademicos.Models;
using System.Linq;

namespace SistemaExpedientesAcademicos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Promedios()
        {
            // Obtener promedios de forma sincrónica
            var expedientes = _context.Expedientes
                .Include(e => e.Alumno)
                .ToList();

            var promedios = expedientes
                .GroupBy(e => new { e.Alumno.AlumnoId, e.Alumno.Nombre, e.Alumno.Apellido, e.Alumno.Grado })
                .Select(g => new PromedioAlumnoViewModel
                {
                    AlumnoId = g.Key.AlumnoId,
                    NombreCompleto = g.Key.Nombre + " " + g.Key.Apellido,
                    Grado = g.Key.Grado,
                    PromedioNotas = g.Average(e => e.NotaFinal),
                    CantidadMaterias = g.Count()
                })
                .OrderByDescending(p => p.PromedioNotas)
                .ToList();

            return View(promedios);
        }
    }
}