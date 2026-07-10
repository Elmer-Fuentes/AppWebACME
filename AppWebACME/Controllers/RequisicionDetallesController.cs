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
    public class RequisicionDetallesController : Controller
    {
        private readonly ACMEContext _context;

        public RequisicionDetallesController(ACMEContext context)
        {
            _context = context;
        }

        // GET: RequisicionDetalles
        public async Task<IActionResult> Index()
        {
            var aCMEContext = _context.RequisicionDetalles.Include(r => r.IdarticuloNavigation).Include(r => r.IdrequisicionNavigation);
            return View(await aCMEContext.ToListAsync());
        }

        // GET: RequisicionDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionDetalle = await _context.RequisicionDetalles
                .Include(r => r.IdarticuloNavigation)
                .Include(r => r.IdrequisicionNavigation)
                .FirstOrDefaultAsync(m => m.IdrequisicionDetalle == id);
            if (requisicionDetalle == null)
            {
                return NotFound();
            }

            return View(requisicionDetalle);
        }

        // GET: RequisicionDetalles/Create
        public IActionResult Create()
        {
            ViewData["Idarticulo"] = new SelectList(_context.Articulos, "Idarticulo", "Idarticulo");
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion");
            return View();
        }

        // POST: RequisicionDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdrequisicionDetalle,Idrequisicion,Idarticulo,Linea,Cantidad,Activo")] RequisicionDetalle requisicionDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicionDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idarticulo"] = new SelectList(_context.Articulos, "Idarticulo", "Idarticulo", requisicionDetalle.Idarticulo);
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionDetalle.Idrequisicion);
            return View(requisicionDetalle);
        }

        // GET: RequisicionDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionDetalle = await _context.RequisicionDetalles.FindAsync(id);
            if (requisicionDetalle == null)
            {
                return NotFound();
            }
            ViewData["Idarticulo"] = new SelectList(_context.Articulos, "Idarticulo", "Idarticulo", requisicionDetalle.Idarticulo);
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionDetalle.Idrequisicion);
            return View(requisicionDetalle);
        }

        // POST: RequisicionDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdrequisicionDetalle,Idrequisicion,Idarticulo,Linea,Cantidad,Activo")] RequisicionDetalle requisicionDetalle)
        {
            if (id != requisicionDetalle.IdrequisicionDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicionDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicionDetalleExists(requisicionDetalle.IdrequisicionDetalle))
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
            ViewData["Idarticulo"] = new SelectList(_context.Articulos, "Idarticulo", "Idarticulo", requisicionDetalle.Idarticulo);
            ViewData["Idrequisicion"] = new SelectList(_context.Requisicions, "Idrequisicion", "Idrequisicion", requisicionDetalle.Idrequisicion);
            return View(requisicionDetalle);
        }

        // GET: RequisicionDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicionDetalle = await _context.RequisicionDetalles
                .Include(r => r.IdarticuloNavigation)
                .Include(r => r.IdrequisicionNavigation)
                .FirstOrDefaultAsync(m => m.IdrequisicionDetalle == id);
            if (requisicionDetalle == null)
            {
                return NotFound();
            }

            return View(requisicionDetalle);
        }

        // POST: RequisicionDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicionDetalle = await _context.RequisicionDetalles.FindAsync(id);
            if (requisicionDetalle != null)
            {
                _context.RequisicionDetalles.Remove(requisicionDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicionDetalleExists(int id)
        {
            return _context.RequisicionDetalles.Any(e => e.IdrequisicionDetalle == id);
        }
    }
}
