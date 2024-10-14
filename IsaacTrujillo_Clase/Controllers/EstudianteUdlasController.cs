using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacTrujillo_Clase.Models;

namespace IsaacTrujillo_Clase.Controllers
{
    public class EstudianteUdlasController : Controller
    {
        private readonly EstudiantesContext _context;

        public EstudianteUdlasController(EstudiantesContext context)
        {
            _context = context;
        }

        // GET: EstudianteUdlas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstudianteUdla.ToListAsync());
        }

        // GET: EstudianteUdlas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUdla = await _context.EstudianteUdla
                .FirstOrDefaultAsync(m => m.IdBanner == id);
            if (estudianteUdla == null)
            {
                return NotFound();
            }

            return View(estudianteUdla);
        }

        // GET: EstudianteUdlas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstudianteUdlas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBanner,Nombre,FechaNacimiento,correo,TieneBeca,IdCarrera")] EstudianteUdla estudianteUdla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteUdla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteUdla);
        }

        // GET: EstudianteUdlas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUdla = await _context.EstudianteUdla.FindAsync(id);
            if (estudianteUdla == null)
            {
                return NotFound();
            }
            return View(estudianteUdla);
        }

        // POST: EstudianteUdlas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBanner,Nombre,FechaNacimiento,correo,TieneBeca,IdCarrera")] EstudianteUdla estudianteUdla)
        {
            if (id != estudianteUdla.IdBanner)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteUdla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteUdlaExists(estudianteUdla.IdBanner))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteUdla);
        }

        // GET: EstudianteUdlas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteUdla = await _context.EstudianteUdla
                .FirstOrDefaultAsync(m => m.IdBanner == id);
            if (estudianteUdla == null)
            {
                return NotFound();
            }

            return View(estudianteUdla);
        }

        // POST: EstudianteUdlas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteUdla = await _context.EstudianteUdla.FindAsync(id);
            if (estudianteUdla != null)
            {
                _context.EstudianteUdla.Remove(estudianteUdla);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteUdlaExists(int id)
        {
            return _context.EstudianteUdla.Any(e => e.IdBanner == id);
        }
    }
}
