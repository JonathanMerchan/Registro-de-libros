using CRUDNetCore5.Data;
using CRUDNetCore5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CRUDNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> LisLibros = _context.Libro;

            return View(LisLibros);
        }
        [HttpGet]
        //HTTP GET
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //HTTP POST
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha creado exitosamente";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //HTTP POST
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();

                TempData["mensaje"] = "El libro se ha Actualizado exitosamente";

                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var libro = _context.Libro.Find(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //HTTP POST
        public IActionResult DeleteLibro(int? id)
        {
            var libro = _context.Libro.Find(id);

            if (libro == null) 
            { 
                return NotFound(); 
            }

            _context.Libro.Remove(libro);
            _context.SaveChanges();

            TempData["mensaje"] = "El libro se ha Eliminado exitosamente";

            return RedirectToAction("Index");                  
        }


    }
}
