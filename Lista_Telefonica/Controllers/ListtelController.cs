using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lista_Telefonica.Data;
using Lista_Telefonica.Models;

namespace Lista_Telefonica.Controllers
{
    public class ListtelController : Controller
    {
        private readonly Lista_TelefonicaContext _context;

        public ListtelController(Lista_TelefonicaContext context)
        {
            _context = context;
        }

        // GET: Listtel
        public async Task<IActionResult> Index()
        {
            return View(await _context.ListaTelModels.ToListAsync());
        }

        // GET: Listtel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelModels = await _context.ListaTelModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (listaTelModels == null)
            {
                return NotFound();
            }

            return View(listaTelModels);
        }

        // GET: Listtel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listtel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,email,telefone")] ListaTelModels listaTelModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaTelModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaTelModels);
        }

        // GET: Listtel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelModels = await _context.ListaTelModels.FindAsync(id);
            if (listaTelModels == null)
            {
                return NotFound();
            }
            return View(listaTelModels);
        }

        // POST: Listtel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,email,telefone")] ListaTelModels listaTelModels)
        {
            if (id != listaTelModels.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaTelModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaTelModelsExists(listaTelModels.id))
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
            return View(listaTelModels);
        }

        // GET: Listtel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaTelModels = await _context.ListaTelModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (listaTelModels == null)
            {
                return NotFound();
            }

            return View(listaTelModels);
        }

        // POST: Listtel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaTelModels = await _context.ListaTelModels.FindAsync(id);
            if (listaTelModels != null)
            {
                _context.ListaTelModels.Remove(listaTelModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaTelModelsExists(int id)
        {
            return _context.ListaTelModels.Any(e => e.id == id);
        }
    }
}
