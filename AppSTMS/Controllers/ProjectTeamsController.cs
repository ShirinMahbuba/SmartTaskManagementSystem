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
    public class ProjectTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectTeams
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectTeam.ToListAsync());
        }

        // GET: ProjectTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTeam = await _context.ProjectTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTeam == null)
            {
                return NotFound();
            }

            return View(projectTeam);
        }

        // GET: ProjectTeams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectTeams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,TeamMemberId")] ProjectTeam projectTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectTeam);
        }

        // GET: ProjectTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTeam = await _context.ProjectTeam.FindAsync(id);
            if (projectTeam == null)
            {
                return NotFound();
            }
            return View(projectTeam);
        }

        // POST: ProjectTeams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,TeamMemberId")] ProjectTeam projectTeam)
        {
            if (id != projectTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTeamExists(projectTeam.Id))
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
            return View(projectTeam);
        }

        // GET: ProjectTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTeam = await _context.ProjectTeam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectTeam == null)
            {
                return NotFound();
            }

            return View(projectTeam);
        }

        // POST: ProjectTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectTeam = await _context.ProjectTeam.FindAsync(id);
            if (projectTeam != null)
            {
                _context.ProjectTeam.Remove(projectTeam);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectTeamExists(int id)
        {
            return _context.ProjectTeam.Any(e => e.Id == id);
        }
    }
}
