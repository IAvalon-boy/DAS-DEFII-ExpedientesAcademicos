using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaExpedientesAcademicos.Data;
using SistemaExpedientesAcademicos.Models;
using System.Linq;

namespace SistemaExpedientesAcademicos.Controllers
{
    public class ExpedientesController : Controller
    {
        private readonly AppDbContext _context;

        public ExpedientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Expedientes
        public IActionResult Index()
        {
            var expedientes = _context.Expedientes
                .Include(e => e.Alumno)
                .Include(e => e.Materia)
                .ToList();
            return View(expedientes);
        }

        // GET: Expedientes/Create
        public IActionResult Create()
        {
            // Cargar listas para los dropdowns
            ViewData["Alumnos"] = _context.Alumnos.ToList();
            ViewData["Materias"] = _context.Materias.ToList();
            return View();
        }

        // POST: Expedientes/Create
        [HttpPost]
        public IActionResult Create(int AlumnoId, int MateriaId, decimal NotaFinal, string Observaciones)
        {
            var expediente = new Expedientes
            {
                AlumnoId = AlumnoId,
                MateriaId = MateriaId,
                NotaFinal = NotaFinal,
                Observaciones = Observaciones
            };

            _context.Expedientes.Add(expediente);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}