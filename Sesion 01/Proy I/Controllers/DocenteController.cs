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
    public class DocentEController : Controller
    {
        private readonly UniversidadContext _context;

        private readonly IConfiguration configuration;

        public DocentEController(IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = new UniversidadContext(configuration);
        }

        // GET: DocentE
        public async Task<IActionResult> Index()
        {
              return _context.docenteModel != null ? 
                          View(await _context.docenteModel.ToListAsync()) :
                          Problem("Entity set 'UniversidadContext.docenteModel'  is null.");
        }

        // GET: DocentE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.docenteModel == null)
            {
                return NotFound();
            }

            var docenteModel = await _context.docenteModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (docenteModel == null)
            {
                return NotFound();
            }

            return View(docenteModel);
        }

        // GET: DocentE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocentE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,apellido")] DocenteModel docenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(docenteModel);
        }

        // GET: DocentE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.docenteModel == null)
            {
                return NotFound();
            }

            var docenteModel = await _context.docenteModel.FindAsync(id);
            if (docenteModel == null)
            {
                return NotFound();
            }
            return View(docenteModel);
        }

        // POST: DocentE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,apellido")] DocenteModel docenteModel)
        {
            if (id != docenteModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docenteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocenteModelExists(docenteModel.id))
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
            return View(docenteModel);
        }

        // GET: DocentE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.docenteModel == null)
            {
                return NotFound();
            }

            var docenteModel = await _context.docenteModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (docenteModel == null)
            {
                return NotFound();
            }

            return View(docenteModel);
        }

        // POST: DocentE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.docenteModel == null)
            {
                return Problem("Entity set 'UniversidadContext.docenteModel'  is null.");
            }
            var docenteModel = await _context.docenteModel.FindAsync(id);
            if (docenteModel != null)
            {
                _context.docenteModel.Remove(docenteModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocenteModelExists(int id)
        {
          return (_context.docenteModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
