using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sqlServerDemo.Data;
using sqlServerDemo.Models;

namespace sqlServerDemo
{
    public class NFT_ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NFT_ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NFT_Product
        public async Task<IActionResult> Index()
        {
            return View(await _context.NFT_Product.ToListAsync());
        }

        // GET: NFT_Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT_Product = await _context.NFT_Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nFT_Product == null)
            {
                return NotFound();
            }

            return View(nFT_Product);
        }

        // GET: NFT_Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NFT_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Rank,CollectionName,ImageUrls,FloorPrice,Volume")] NFT_Product nFT_Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nFT_Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nFT_Product);
        }

        // GET: NFT_Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT_Product = await _context.NFT_Product.FindAsync(id);
            if (nFT_Product == null)
            {
                return NotFound();
            }
            return View(nFT_Product);
        }

        // POST: NFT_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Rank,CollectionName,ImageUrls,FloorPrice,Volume")] NFT_Product nFT_Product)
        {
            if (id != nFT_Product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nFT_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NFT_ProductExists(nFT_Product.ID))
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
            return View(nFT_Product);
        }

        // GET: NFT_Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nFT_Product = await _context.NFT_Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nFT_Product == null)
            {
                return NotFound();
            }

            return View(nFT_Product);
        }

        // POST: NFT_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nFT_Product = await _context.NFT_Product.FindAsync(id);
            if (nFT_Product != null)
            {
                _context.NFT_Product.Remove(nFT_Product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NFT_ProductExists(int id)
        {
            return _context.NFT_Product.Any(e => e.ID == id);
        }
    }
}
