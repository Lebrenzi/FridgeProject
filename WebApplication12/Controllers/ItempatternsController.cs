using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class ItempatternsController : Controller
    {
        private readonly fridgeContext _context = new fridgeContext();

        // GET: Itempatterns
        [Authorize]
        public async Task<IActionResult> Index()
        {
            try
            {
                String email = User.Identity.Name;
                var query = from p in _context.User where p.Email.Equals(email) select p;
                User cur_user = query.Single();
                var query_1 = from itempattern in _context.Itempattern
                              join item in _context.Item on itempattern.ItemPatternId equals item.ItemPatterId
                              join shelf in _context.Shelf on item.ShelfId equals shelf.ShelfId
                              join storage in _context.Storage on shelf.StorageId equals storage.StorageId
                              join privelege in _context.Privilege on storage.StorageId equals privelege.StorageId
                              join user in _context.User on privelege.UserId equals user.UserId
                              where user == cur_user
                              select itempattern;
                var list1 = query_1.Distinct().ToList();
                return View(list1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        // GET: Itempatterns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itempattern = await _context.Itempattern
                .Include(i => i.CategoryItemPattern)
                .FirstOrDefaultAsync(m => m.ItemPatternId == id);
            if (itempattern == null)
            {
                return NotFound();
            }

            return View(itempattern);
        }

        // GET: Itempatterns/Create
        public IActionResult Create()
        {
            ViewData["CategoryItemPatternId"] = new SelectList(_context.Categoryitempattern, "CategoryItemPatternId", "Name");
            return View();
        }

        // POST: Itempatterns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemPatternId,CategoryItemPatternId,BarCode,Unit,Size,Name,Capacity,LongLife")] Itempattern itempattern)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itempattern);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryItemPatternId"] = new SelectList(_context.Categoryitempattern, "CategoryItemPatternId", "Name", itempattern.CategoryItemPatternId);
            return View(itempattern);
        }

        // GET: Itempatterns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itempattern = await _context.Itempattern.FindAsync(id);
            if (itempattern == null)
            {
                return NotFound();
            }
            ViewData["CategoryItemPatternId"] = new SelectList(_context.Categoryitempattern, "CategoryItemPatternId", "Name", itempattern.CategoryItemPatternId);
            return View(itempattern);
        }

        // POST: Itempatterns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemPatternId,CategoryItemPatternId,BarCode,Unit,Size,Name,Capacity,LongLife")] Itempattern itempattern)
        {
            if (id != itempattern.ItemPatternId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itempattern);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItempatternExists(itempattern.ItemPatternId))
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
            ViewData["CategoryItemPatternId"] = new SelectList(_context.Categoryitempattern, "CategoryItemPatternId", "Name", itempattern.CategoryItemPatternId);
            return View(itempattern);
        }

        // GET: Itempatterns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itempattern = await _context.Itempattern
                .Include(i => i.CategoryItemPattern)
                .FirstOrDefaultAsync(m => m.ItemPatternId == id);
            if (itempattern == null)
            {
                return NotFound();
            }

            return View(itempattern);
        }

        // POST: Itempatterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itempattern = await _context.Itempattern.FindAsync(id);
            _context.Itempattern.Remove(itempattern);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItempatternExists(int id)
        {
            return _context.Itempattern.Any(e => e.ItemPatternId == id);
        }
    }
}
