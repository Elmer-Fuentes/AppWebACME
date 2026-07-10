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
    public class TiposEmpresaController : Controller
    {
        private readonly ACMEContext _context;

        public TiposEmpresaController(ACMEContext context)
        {
            _context = context;
        }

        // GET: TiposEmpresa
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEmpresas.ToListAsync());
        }

        // GET: TiposEmpresa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpresa = await _context.TipoEmpresas
                .FirstOrDefaultAsync(m => m.IdtipoEmpresa == id);
            if (tipoEmpresa == null)
            {
                return NotFound();
            }

            return View(tipoEmpresa);
        }

        // GET: TiposEmpresa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposEmpresa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdtipoEmpresa,TipoEmpresa1,Descripción,Sigla,Activo")] TipoEmpresa tipoEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEmpresa);
        }

        // GET: TiposEmpresa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpresa = await _context.TipoEmpresas.FindAsync(id);
            if (tipoEmpresa == null)
            {
                return NotFound();
            }
            return View(tipoEmpresa);
        }

        // POST: TiposEmpresa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdtipoEmpresa,TipoEmpresa1,Descripción,Sigla,Activo")] TipoEmpresa tipoEmpresa)
        {
            if (id != tipoEmpresa.IdtipoEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEmpresaExists(tipoEmpresa.IdtipoEmpresa))
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
            return View(tipoEmpresa);
        }

        // GET: TiposEmpresa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEmpresa = await _context.TipoEmpresas
                .FirstOrDefaultAsync(m => m.IdtipoEmpresa == id);
            if (tipoEmpresa == null)
            {
                return NotFound();
            }

            return View(tipoEmpresa);
        }

        // POST: TiposEmpresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEmpresa = await _context.TipoEmpresas.FindAsync(id);
            if (tipoEmpresa != null)
            {
                _context.TipoEmpresas.Remove(tipoEmpresa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEmpresaExists(int id)
        {
            return _context.TipoEmpresas.Any(e => e.IdtipoEmpresa == id);
        }
    }
}
