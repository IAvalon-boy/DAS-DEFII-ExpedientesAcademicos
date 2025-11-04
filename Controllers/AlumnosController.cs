using Microsoft.AspNetCore.Mvc;
using SistemaExpedientesAcademicos.Data;
using SistemaExpedientesAcademicos.Models;
using System.Linq;

namespace SistemaExpedientesAcademicos.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly AppDbContext _context;

        public AlumnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Alumnos
        public IActionResult Index()
        {
            var alumnos = _context.Alumnos.ToList();
            return View(alumnos);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public IActionResult Create(Alumno alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}