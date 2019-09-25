using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tennis2.Data;
using Tennis2.Models;

namespace Tennis2.Controllers
{
    public class ClassMemberCoachesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassMemberCoachesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClassMemberCoaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassMemberCoach.ToListAsync());
        }

        // GET: ClassMemberCoaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMemberCoach = await _context.ClassMemberCoach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classMemberCoach == null)
            {
                return NotFound();
            }

            return View(classMemberCoach);
        }

        // GET: ClassMemberCoaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassMemberCoaches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoachName,MemberName,ClassName")] ClassMemberCoach classMemberCoach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classMemberCoach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classMemberCoach);
        }

        // GET: ClassMemberCoaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMemberCoach = await _context.ClassMemberCoach.FindAsync(id);
            if (classMemberCoach == null)
            {
                return NotFound();
            }
            return View(classMemberCoach);
        }

        // POST: ClassMemberCoaches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoachName,MemberName,ClassName")] ClassMemberCoach classMemberCoach)
        {
            if (id != classMemberCoach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classMemberCoach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassMemberCoachExists(classMemberCoach.Id))
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
            return View(classMemberCoach);
        }

        // GET: ClassMemberCoaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classMemberCoach = await _context.ClassMemberCoach
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classMemberCoach == null)
            {
                return NotFound();
            }

            return View(classMemberCoach);
        }

        // POST: ClassMemberCoaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classMemberCoach = await _context.ClassMemberCoach.FindAsync(id);
            _context.ClassMemberCoach.Remove(classMemberCoach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassMemberCoachExists(int id)
        {
            return _context.ClassMemberCoach.Any(e => e.Id == id);
        }
    }
}
