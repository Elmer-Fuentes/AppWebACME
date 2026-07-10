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
    public class RequisicionesController : Controller
    {
        private readonly ACMEContext _context;

        public RequisicionesController(ACMEContext context)
        {
            _context = context;
        }

        // GET: Requisiciones
        public async Task<IActionResult> Index()
        {
            var aCMEContext = _context.Requisicions.Include(r => r.IdempresaNavigation);
            return View(await aCMEContext.ToListAsync());
        }

        // GET: Requisiciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicion = await _context.Requisicions
                .Include(r => r.IdempresaNavigation)
                .FirstOrDefaultAsync(m => m.Idrequisicion == id);
            if (requisicion == null)
            {
                return NotFound();
            }

            return View(requisicion);
        }

        // GET: Requisiciones/Create
        public IActionResult Create()
        {
            ViewData["Idempresa"] = new SelectList(_context.Empresas, "Idempresa", "Idempresa");
            return View();
        }

        // POST: Requisiciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrequisicion,Idempresa,NroRequiscion,FechaEmision,Aprobada,Activo")] Requisicion requisicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requisicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idempresa"] = new SelectList(_context.Empresas, "Idempresa", "Idempresa", requisicion.Idempresa);
            return View(requisicion);
        }

        // GET: Requisiciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicion = await _context.Requisicions.FindAsync(id);
            if (requisicion == null)
            {
                return NotFound();
            }
            ViewData["Idempresa"] = new SelectList(_context.Empresas, "Idempresa", "Idempresa", requisicion.Idempresa);
            return View(requisicion);
        }

        // POST: Requisiciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrequisicion,Idempresa,NroRequiscion,FechaEmision,Aprobada,Activo")] Requisicion requisicion)
        {
            if (id != requisicion.Idrequisicion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requisicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequisicionExists(requisicion.Idrequisicion))
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
            ViewData["Idempresa"] = new SelectList(_context.Empresas, "Idempresa", "Idempresa", requisicion.Idempresa);
            return View(requisicion);
        }

        // GET: Requisiciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requisicion = await _context.Requisicions
                .Include(r => r.IdempresaNavigation)
                .FirstOrDefaultAsync(m => m.Idrequisicion == id);
            if (requisicion == null)
            {
                return NotFound();
            }

            return View(requisicion);
        }

        // POST: Requisiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requisicion = await _context.Requisicions.FindAsync(id);
            if (requisicion != null)
            {
                _context.Requisicions.Remove(requisicion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequisicionExists(int id)
        {
            return _context.Requisicions.Any(e => e.Idrequisicion == id);
        }
    }
}
