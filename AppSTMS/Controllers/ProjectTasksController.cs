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
    public class ProjectTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectTasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectTask.Include(p => p.Project).Include(p => p.ProjectTaskStatus).Include(p => p.TaskPriority).Include(p => p.TeamMember);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTask
                .Include(p => p.Project)
                .Include(p => p.ProjectTaskStatus)
                .Include(p => p.TaskPriority)
                .Include(p => p.TeamMember)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // GET: ProjectTasks/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle");
            ViewData["ProjectTaskStatusId"] = new SelectList(_context.ProjectTaskStatus, "Id", "StatusName");
            ViewData["TaskPriorityId"] = new SelectList(_context.TaskPriority, "Id", "PriorityName");
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMember, "Id", "Email");
            return View();
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,TaskName,TaskDesc,TeamMemberId,ProjectTaskStatusId,TaskPriorityId,CreatedOn,UpdatedOn,CompletedOn,CreatedBy,UpdatedBy,CompletedBy")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle", projectTask.ProjectId);
            ViewData["ProjectTaskStatusId"] = new SelectList(_context.ProjectTaskStatus, "Id", "StatusName", projectTask.ProjectTaskStatusId);
            ViewData["TaskPriorityId"] = new SelectList(_context.TaskPriority, "Id", "PriorityName", projectTask.TaskPriorityId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMember, "Id", "Email", projectTask.TeamMemberId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTask.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle", projectTask.ProjectId);
            ViewData["ProjectTaskStatusId"] = new SelectList(_context.ProjectTaskStatus, "Id", "StatusName", projectTask.ProjectTaskStatusId);
            ViewData["TaskPriorityId"] = new SelectList(_context.TaskPriority, "Id", "PriorityName", projectTask.TaskPriorityId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMember, "Id", "Email", projectTask.TeamMemberId);
            return View(projectTask);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,TaskName,TaskDesc,TeamMemberId,ProjectTaskStatusId,TaskPriorityId,CreatedOn,UpdatedOn,CompletedOn,CreatedBy,UpdatedBy,CompletedBy")] ProjectTask projectTask)
        {
            if (id != projectTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskExists(projectTask.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectTitle", projectTask.ProjectId);
            ViewData["ProjectTaskStatusId"] = new SelectList(_context.ProjectTaskStatus, "Id", "StatusName", projectTask.ProjectTaskStatusId);
            ViewData["TaskPriorityId"] = new SelectList(_context.TaskPriority, "Id", "PriorityName", projectTask.TaskPriorityId);
            ViewData["TeamMemberId"] = new SelectList(_context.TeamMember, "Id", "Email", projectTask.TeamMemberId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _context.ProjectTask
                .Include(p => p.Project)
                .Include(p => p.ProjectTaskStatus)
                .Include(p => p.TaskPriority)
                .Include(p => p.TeamMember)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectTask = await _context.ProjectTask.FindAsync(id);
            if (projectTask != null)
            {
                _context.ProjectTask.Remove(projectTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTaskExists(int id)
        {
            return _context.ProjectTask.Any(e => e.Id == id);
        }
    }
}
