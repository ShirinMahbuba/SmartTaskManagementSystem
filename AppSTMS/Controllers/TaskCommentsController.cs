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
    public class TaskCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskComments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaskComments.Include(t => t.ProjectTasks).Include(t => t.ProjectTeam);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaskComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskComments = await _context.TaskComments
                .Include(t => t.ProjectTasks)
                .Include(t => t.ProjectTeam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskComments == null)
            {
                return NotFound();
            }

            return View(taskComments);
        }

        // GET: TaskComments/Create
        public IActionResult Create()
        {
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc");
            ViewData["ProjectTeamId"] = new SelectList(_context.ProjectTeam, "Id", "TeamMemberId");
            return View();
        }

        // POST: TaskComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectTaskId,ProjectTeamId,Remarks,PostTime")] TaskComments taskComments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskComments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskComments.ProjectTaskId);
            ViewData["ProjectTeamId"] = new SelectList(_context.ProjectTeam, "Id", "TeamMemberId", taskComments.ProjectTeamId);
            return View(taskComments);
        }

        // GET: TaskComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskComments = await _context.TaskComments.FindAsync(id);
            if (taskComments == null)
            {
                return NotFound();
            }
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskComments.ProjectTaskId);
            ViewData["ProjectTeamId"] = new SelectList(_context.ProjectTeam, "Id", "TeamMemberId", taskComments.ProjectTeamId);
            return View(taskComments);
        }

        // POST: TaskComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectTaskId,ProjectTeamId,Remarks,PostTime")] TaskComments taskComments)
        {
            if (id != taskComments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskComments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskCommentsExists(taskComments.Id))
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
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTask, "Id", "TaskDesc", taskComments.ProjectTaskId);
            ViewData["ProjectTeamId"] = new SelectList(_context.ProjectTeam, "Id", "TeamMemberId", taskComments.ProjectTeamId);
            return View(taskComments);
        }

        // GET: TaskComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskComments = await _context.TaskComments
                .Include(t => t.ProjectTasks)
                .Include(t => t.ProjectTeam)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskComments == null)
            {
                return NotFound();
            }

            return View(taskComments);
        }

        // POST: TaskComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskComments = await _context.TaskComments.FindAsync(id);
            if (taskComments != null)
            {
                _context.TaskComments.Remove(taskComments);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskCommentsExists(int id)
        {
            return _context.TaskComments.Any(e => e.Id == id);
        }
    }
}
