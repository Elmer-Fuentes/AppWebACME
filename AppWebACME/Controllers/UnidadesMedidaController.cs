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
    public class UnidadesMedidaController : Controller
    {
        private readonly ACMEContext _context;

        public UnidadesMedidaController(ACMEContext context)
        {
            _context = context;
        }

        // GET: UnidadesMedida
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadMedida.ToListAsync());
        }

        // GET: UnidadesMedida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidum = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.IdunidadMedida == id);
            if (unidadMedidum == null)
            {
                return NotFound();
            }

            return View(unidadMedidum);
        }

        // GET: UnidadesMedida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadesMedida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdunidadMedida,UnidadMedida,Sigla,Activo")] UnidadMedidum unidadMedidum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadMedidum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadMedidum);
        }

        // GET: UnidadesMedida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedidum == null)
            {
                return NotFound();
            }
            return View(unidadMedidum);
        }

        // POST: UnidadesMedida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdunidadMedida,UnidadMedida,Sigla,Activo")] UnidadMedidum unidadMedidum)
        {
            if (id != unidadMedidum.IdunidadMedida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadMedidum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadMedidumExists(unidadMedidum.IdunidadMedida))
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
            return View(unidadMedidum);
        }

        // GET: UnidadesMedida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadMedidum = await _context.UnidadMedida
                .FirstOrDefaultAsync(m => m.IdunidadMedida == id);
            if (unidadMedidum == null)
            {
                return NotFound();
            }

            return View(unidadMedidum);
        }

        // POST: UnidadesMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadMedidum = await _context.UnidadMedida.FindAsync(id);
            if (unidadMedidum != null)
            {
                _context.UnidadMedida.Remove(unidadMedidum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadMedidumExists(int id)
        {
            return _context.UnidadMedida.Any(e => e.IdunidadMedida == id);
        }
    }
}
