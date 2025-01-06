﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class PhoneProgramsController : Controller
    {
        private readonly MVCProjContext _context;

        public PhoneProgramsController(MVCProjContext context)
        {
            _context = context;
        }

        // GET: PhonePrograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programs.ToListAsync());
        }

        // GET: PhonePrograms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneProgram = await _context.Programs
                .FirstOrDefaultAsync(m => m.ProgramName == id);
            if (phoneProgram == null)
            {
                return NotFound();
            }

            return View(phoneProgram);
        }

        // GET: PhonePrograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhonePrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramName,Benefits,Charge")] PhoneProgram phoneProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneProgram);
        }

        // GET: PhonePrograms/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneProgram = await _context.Programs.FindAsync(id);
            if (phoneProgram == null)
            {
                return NotFound();
            }
            return View(phoneProgram);
        }

        // POST: PhonePrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProgramName,Benefits,Charge")] PhoneProgram phoneProgram)
        {
            if (id != phoneProgram.ProgramName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneProgramExists(phoneProgram.ProgramName))
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
            return View(phoneProgram);
        }

        // GET: PhonePrograms/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneProgram = await _context.Programs
                .FirstOrDefaultAsync(m => m.ProgramName == id);
            if (phoneProgram == null)
            {
                return NotFound();
            }

            return View(phoneProgram);
        }

        // POST: PhonePrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phoneProgram = await _context.Programs.FindAsync(id);
            if (phoneProgram != null)
            {
                _context.Programs.Remove(phoneProgram);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneProgramExists(string id)
        {
            return _context.Programs.Any(e => e.ProgramName == id);
        }
    }
}