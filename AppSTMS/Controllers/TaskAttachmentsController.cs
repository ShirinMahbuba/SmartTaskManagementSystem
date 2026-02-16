using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppSTMS.Data;
using AppSTMS.Models;

namespace AppSTMS.Controllers
{
    public class TaskAttachmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskAttachmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskAttachments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskAttachments.Include(t => t.ProjectTasks);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskAttachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAttachments = await _context.TaskAttachments
                .Include(t => t.ProjectTasks)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskAttachments == null)
            {
                return NotFound();
            }

            return View(taskAttachments);
        }

        // GET: TaskAttachments/Create
        public IActionResult Create()
        {
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc");
            return View();
        }

        // POST: TaskAttachments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectTaskId,AttFileName,Remarks")] TaskAttachments taskAttachments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskAttachments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskAttachments.ProjectTaskId);
            return View(taskAttachments);
        }

        // GET: TaskAttachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAttachments = await _context.TaskAttachments.FindAsync(id);
            if (taskAttachments == null)
            {
                return NotFound();
            }
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskAttachments.ProjectTaskId);
            return View(taskAttachments);
        }

        // POST: TaskAttachments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectTaskId,AttFileName,Remarks")] TaskAttachments taskAttachments)
        {
            if (id != taskAttachments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskAttachments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskAttachmentsExists(taskAttachments.Id))
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
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskAttachments.ProjectTaskId);
            return View(taskAttachments);
        }

        // GET: TaskAttachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAttachments = await _context.TaskAttachments
                .Include(t => t.ProjectTasks)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskAttachments == null)
            {
                return NotFound();
            }

            return View(taskAttachments);
        }

        // POST: TaskAttachments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskAttachments = await _context.TaskAttachments.FindAsync(id);
            if (taskAttachments != null)
            {
                _context.TaskAttachments.Remove(taskAttachments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskAttachmentsExists(int id)
        {
            return _context.TaskAttachments.Any(e => e.Id == id);
        }
    }
}
