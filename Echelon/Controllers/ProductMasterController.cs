using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Echelon.Models;

namespace Echelon.Controllers
{
    public class ProductMasterController : Controller
    {
        private readonly EchelonContext _context;

        public ProductMasterController(EchelonContext context)
        {
            _context = context;
        }

        // GET: ProductMaster
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductMasters.ToListAsync());
        }

        // GET: ProductMaster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return View(productMaster);
        }

        // GET: ProductMaster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ManufacturerCode,ProductName,Specifications,PurchasePrice,ListPrice")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productMaster);
        }

        // GET: ProductMaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters.FindAsync(id);
            if (productMaster == null)
            {
                return NotFound();
            }
            return View(productMaster);
        }

        // POST: ProductMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ManufacturerCode,ProductName,Specifications,PurchasePrice,ListPrice")] ProductMaster productMaster)
        {
            if (id != productMaster.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMasterExists(productMaster.ProductId))
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
            return View(productMaster);
        }

        // GET: ProductMaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMaster = await _context.ProductMasters
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMaster == null)
            {
                return NotFound();
            }

            return View(productMaster);
        }

        // POST: ProductMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMaster = await _context.ProductMasters.FindAsync(id);
            if (productMaster != null)
            {
                _context.ProductMasters.Remove(productMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMasterExists(int id)
        {
            return _context.ProductMasters.Any(e => e.ProductId == id);
        }
    }
}
