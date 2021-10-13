using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Correlativos
{
    public class CorrelativoesController : Controller
    {
        private readonly CorrelativoDBContext _context;

        public CorrelativoesController(CorrelativoDBContext context)
        {
            _context = context;
        }

        // GET: Correlativoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.correlativo.ToListAsync());
        }

        // GET: Correlativoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correlativo = await _context.correlativo
                .FirstOrDefaultAsync(m => m.idCorrelativo == id);
            if (correlativo == null)
            {
                return NotFound();
            }

            return View(correlativo);
        }

        // GET: Correlativoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Correlativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCorrelativo,descripcion,monto")] Correlativo correlativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(correlativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(correlativo);
        }

        // GET: Correlativoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correlativo = await _context.correlativo.FindAsync(id);
            if (correlativo == null)
            {
                return NotFound();
            }
            return View(correlativo);
        }

        // POST: Correlativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCorrelativo,descripcion,monto")] Correlativo correlativo)
        {
            if (id != correlativo.idCorrelativo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(correlativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorrelativoExists(correlativo.idCorrelativo))
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
            return View(correlativo);
        }

        // GET: Correlativoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correlativo = await _context.correlativo
                .FirstOrDefaultAsync(m => m.idCorrelativo == id);
            if (correlativo == null)
            {
                return NotFound();
            }

            return View(correlativo);
        }

        // POST: Correlativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correlativo = await _context.correlativo.FindAsync(id);
            _context.correlativo.Remove(correlativo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorrelativoExists(int id)
        {
            return _context.correlativo.Any(e => e.idCorrelativo == id);
        }
    }
}
