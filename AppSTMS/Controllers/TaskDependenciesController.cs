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
    public class TaskDependenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskDependenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskDependencies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskDependency.Include(t => t.DependsOnTask).Include(t => t.ProjectTasks);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskDependencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDependency = await _context.TaskDependency
                .Include(t => t.DependsOnTask)
                .Include(t => t.ProjectTasks)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDependency == null)
            {
                return NotFound();
            }

            return View(taskDependency);
        }

        // GET: TaskDependencies/Create
        public IActionResult Create()
        {
            ViewData["DependsOnTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc");
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc");
            return View();
        }

        // POST: TaskDependencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectTaskId,DependsOnTaskId,Remarks")] TaskDependency taskDependency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskDependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DependsOnTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.DependsOnTaskId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.ProjectTaskId);
            return View(taskDependency);
        }

        // GET: TaskDependencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDependency = await _context.TaskDependency.FindAsync(id);
            if (taskDependency == null)
            {
                return NotFound();
            }
            ViewData["DependsOnTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.DependsOnTaskId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.ProjectTaskId);
            return View(taskDependency);
        }

        // POST: TaskDependencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectTaskId,DependsOnTaskId,Remarks")] TaskDependency taskDependency)
        {
            if (id != taskDependency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskDependency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDependencyExists(taskDependency.Id))
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
            ViewData["DependsOnTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.DependsOnTaskId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskDependency.ProjectTaskId);
            return View(taskDependency);
        }

        // GET: TaskDependencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDependency = await _context.TaskDependency
                .Include(t => t.DependsOnTask)
                .Include(t => t.ProjectTasks)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDependency == null)
            {
                return NotFound();
            }

            return View(taskDependency);
        }

        // POST: TaskDependencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDependency = await _context.TaskDependency.FindAsync(id);
            if (taskDependency != null)
            {
                _context.TaskDependency.Remove(taskDependency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskDependencyExists(int id)
        {
            return _context.TaskDependency.Any(e => e.Id == id);
        }
    }
}
