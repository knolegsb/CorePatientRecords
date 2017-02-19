using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CorePatientRecords.Data;
using Microsoft.EntityFrameworkCore;
using CorePatientRecords.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePatientRecords.Controllers
{
    public class HumanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HumanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Human.ToListAsync());
        }

        // GET: Human/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Human.SingleOrDefaultAsync(m => m.Id == id);
            if (human == null)
            {
                return NotFound();
            }

            return View(human);
        }

        // GET: Human/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, DateOfBirth, FirstName, LastName, SocialSecurityNumber")] Human human)
        {
            if (ModelState.IsValid)
            {
                _context.Add(human);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(human);
        }

        // GET: Human/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Human.SingleOrDefaultAsync(m => m.Id == id);
            if (human == null)
            {
                return NotFound();
            }
            return View(human);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, DateOfBirth, FirstName, LastName, SocialSecurityNumber")] Human human)
        {
            if (id != human.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(human);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HumanExists(human.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(human);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var human = await _context.Human.SingleOrDefaultAsync(m => m.Id == id);
            if (human == null)
            {
                return NotFound();
            }
            return View(human);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var human = await _context.Human.SingleOrDefaultAsync(m => m.Id == id);
            _context.Human.Remove(human);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HumanExists(int id)
        {
            return _context.Human.Any(e => e.Id == id);
        }
    }
}
