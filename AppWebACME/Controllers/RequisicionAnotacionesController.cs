using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWebACME.Data;
using AppWebACME.Models;

namespace AppWebACME.Controllers
{
    public class RequisicionAnotacionesController : Controller
    {
        private readonly ACMEContext _context;

        public RequisicionAnotacionesController(ACMEContext context)
        {
            _context = context;
        }

        // GET: RequisicionAnotaciones
        public async Task<IActionResult> Index()
        {
            var aCMEContext = _context.RequisicionAnotacions.Include(r => r.IdrequisicionNavigation);
            return View(await aCMEContext.ToListAsync());
        }

        // GET: RequisicionAnotaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionAnotacion = await _context.RequisicionAnotacions
                .Include(r => r.IdrequisicionNavigation)
                .FirstOrDefaultAsync(m => m.IdrequisicionAnotacion == id);
            if (requisicionAnotacion == null)
            {
                return NotFound();
            }

            return View(requisicionAnotacion);
        }

        // GET: RequisicionAnotaciones/Create
        public IActionResult Create()
        {
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion");
            return View();
        }

        // POST: RequisicionAnotaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdrequisicionAnotacion,Idrequisicion,Anotacion,Activo")] RequisicionAnotacion requisicionAnotacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicionAnotacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionAnotacion.Idrequisicion);
            return View(requisicionAnotacion);
        }

        // GET: RequisicionAnotaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionAnotacion = await _context.RequisicionAnotacions.FindAsync(id);
            if (requisicionAnotacion == null)
            {
                return NotFound();
            }
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionAnotacion.Idrequisicion);
            return View(requisicionAnotacion);
        }

        // POST: RequisicionAnotaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdrequisicionAnotacion,Idrequisicion,Anotacion,Activo")] RequisicionAnotacion requisicionAnotacion)
        {
            if (id != requisicionAnotacion.IdrequisicionAnotacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicionAnotacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicionAnotacionExists(requisicionAnotacion.IdrequisicionAnotacion))
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
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionAnotacion.Idrequisicion);
            return View(requisicionAnotacion);
        }

        // GET: RequisicionAnotaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionAnotacion = await _context.RequisicionAnotacions
                .Include(r => r.IdrequisicionNavigation)
                .FirstOrDefaultAsync(m => m.IdrequisicionAnotacion == id);
            if (requisicionAnotacion == null)
            {
                return NotFound();
            }

            return View(requisicionAnotacion);
        }

        // POST: RequisicionAnotaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicionAnotacion = await _context.RequisicionAnotacions.FindAsync(id);
            if (requisicionAnotacion != null)
            {
                _context.RequisicionAnotacions.Remove(requisicionAnotacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicionAnotacionExists(int id)
        {
            return _context.RequisicionAnotacions.Any(e => e.IdrequisicionAnotacion == id);
        }
    }
}
