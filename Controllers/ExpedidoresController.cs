﻿using Commpay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Commpay.Controllers
{
    public class ExpedidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedidoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expedidores
        public async Task<IActionResult> Index()
        {
              return _context.Expedidores != null ? 
                          View(await _context.Expedidores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Expedidores'  is null.");
        }

        // GET: Expedidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Expedidores == null)
            {
                return NotFound();
            }

            var expedidor = await _context.Expedidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedidor == null)
            {
                return NotFound();
            }

            return View(expedidor);
        }

        // GET: Expedidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expedidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Senha,Cargo")] Expedidor expedidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expedidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expedidor);
        }

        // GET: Expedidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Expedidores == null)
            {
                return NotFound();
            }

            var expedidor = await _context.Expedidores.FindAsync(id);
            if (expedidor == null)
            {
                return NotFound();
            }
            return View(expedidor);
        }

        // POST: Expedidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Senha,Cargo")] Expedidor expedidor)
        {
            if (id != expedidor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expedidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpedidorExists(expedidor.Id))
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
            return View(expedidor);
        }

        // GET: Expedidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Expedidores == null)
            {
                return NotFound();
            }

            var expedidor = await _context.Expedidores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expedidor == null)
            {
                return NotFound();
            }

            return View(expedidor);
        }

        // POST: Expedidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Expedidores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Expedidores'  is null.");
            }
            var expedidor = await _context.Expedidores.FindAsync(id);
            if (expedidor != null)
            {
                _context.Expedidores.Remove(expedidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedidorExists(int id)
        {
          return (_context.Expedidores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}