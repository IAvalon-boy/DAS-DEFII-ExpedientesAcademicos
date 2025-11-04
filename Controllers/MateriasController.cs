using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using SistemaExpedientesAcademicos.Data;
using SistemaExpedientesAcademicos.Models;

namespace SistemaExpedientesAcademicos.Controllers
{
    public class MateriasController : Controller
    {
        private readonly AppDbContext _context;

        public MateriasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Materias
        public IActionResult Index()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        public IActionResult Create(Materias materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}