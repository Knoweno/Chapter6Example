﻿using Chapter6Example1.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Chapter6Example1.Controllers
{
    public class InstructorController : Controller
    {
       
        SchoolDbContext db;
        public InstructorController(SchoolDbContext db) {
            this.db=db;

        }
        public async Task<IActionResult> AllInstructor()
        {
            var instructor = await db.Instructors.ToListAsync();
            return View(instructor);
        }
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructor(Instructor instructor)
        {
            db.Add(instructor);
            await db.SaveChangesAsync();
            return RedirectToAction("AllInstructor");
        }
        public async Task <IActionResult> InstructorDetails(int? id)
        {
            var instructor = await db.Instructors.SingleOrDefaultAsync(i => i.InstructorId == id);
            return View(instructor);
        }
    }
}

