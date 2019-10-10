using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkLogger.Models;

namespace WorkLogger.Controllers
{
    public class WorkingLogsController : Controller
    {
        private readonly WorkLogDbContext _context;

        public WorkingLogsController(WorkLogDbContext context)
        {
            _context = context;
        }

        // GET: WorkingLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkingLog.OrderBy(wl => wl.Date).ToListAsync());
        }

        // GET: WorkingLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingLog = await _context.WorkingLog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workingLog == null)
            {
                return NotFound();
            }

            return View(workingLog);
        }

        // GET: WorkingLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkingLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,EntranceTime,ExitTime,Date")] WorkingLog workingLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workingLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workingLog);
        }

        // GET: WorkingLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workingLog = await _context.WorkingLog.FindAsync(id);
            if (workingLog == null)
            {
                return NotFound();
            }
            return View(workingLog);
        }

        // POST: WorkingLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,EntranceTime,ExitTime,Date")] WorkingLog workingLog)
        {
            if (id != workingLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workingLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkingLogExists(workingLog.Id))
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
            return View(workingLog);
        }

        // POST: WorkingLogs/Delete/5
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var workingLog = await _context.WorkingLog.FindAsync(id);
            _context.WorkingLog.Remove(workingLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkingLogExists(int id)
        {
            return _context.WorkingLog.Any(e => e.Id == id);
        }
    }
}
