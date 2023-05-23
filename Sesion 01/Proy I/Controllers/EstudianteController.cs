using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proy_I.Models;

namespace Proy_I.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly UniversidadContext _context;

        private readonly IConfiguration configuration;

        public EstudianteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = new UniversidadContext(configuration);
        }

        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
              return _context.estudianteModel != null ? 
                          View(await _context.estudianteModel.ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.estudianteModel'  is null.");
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estudianteModel == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.estudianteModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // GET: Estudiante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,apellido")] EstudianteModel estudianteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudianteModel);
        }

        // GET: Estudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estudianteModel == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.estudianteModel.FindAsync(id);
            if (estudianteModel == null)
            {
                return NotFound();
            }
            return View(estudianteModel);
        }

        // POST: Estudiante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,apellido")] EstudianteModel estudianteModel)
        {
            if (id != estudianteModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteModelExists(estudianteModel.id))
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
            return View(estudianteModel);
        }

        // GET: Estudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estudianteModel == null)
            {
                return NotFound();
            }

            var estudianteModel = await _context.estudianteModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (estudianteModel == null)
            {
                return NotFound();
            }

            return View(estudianteModel);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estudianteModel == null)
            {
                return Problem("Entity set 'UniversidadContext.estudianteModel'  is null.");
            }
            var estudianteModel = await _context.estudianteModel.FindAsync(id);
            if (estudianteModel != null)
            {
                _context.estudianteModel.Remove(estudianteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteModelExists(int id)
        {
          return (_context.estudianteModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
