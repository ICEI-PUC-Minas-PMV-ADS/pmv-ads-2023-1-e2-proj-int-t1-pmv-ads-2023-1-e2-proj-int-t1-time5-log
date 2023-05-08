﻿using Commpay.Models;
using Commpay.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Commpay.Controllers
{
    public class ExpedidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpedidoresController(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return View(usuarios);
        }

        // GET Expedidores/Entregas
        public async Task<IActionResult> Entregas()
        {
            var entregas = await _context.Vendas.ToListAsync();
            return View(entregas);
        }

        [HttpPost]
        public IActionResult Edit(int id, string entregador, Status status)
        {
            var venda = _context.Vendas.FirstOrDefault(v => v.Id == id);

            if (venda == null)
            {
                return NotFound();
            }

            venda.Entregador = entregador;
            venda.Status = status;

            _context.SaveChanges();

            return RedirectToAction("Entregas");
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
                expedidor.Senha = BCrypt.Net.BCrypt.HashPassword(expedidor.Senha);
                _context.Add(expedidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(expedidor);
        }

        // GET: Expedidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
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

        //// POST: Expedidores/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Senha,Cargo")] Expedidor expedidor)
        //{
        //    if (id != expedidor.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            expedidor.Senha = BCrypt.Net.BCrypt.HashPassword(expedidor.Senha);
        //            _context.Update(expedidor);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ExpedidorExists(expedidor.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(expedidor);
        //}

        // GET: Expedidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Expedidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Expedidores'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpedidorExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}