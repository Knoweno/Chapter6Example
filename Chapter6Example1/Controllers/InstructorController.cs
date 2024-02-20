using Chapter6Example1.Models;
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
    }
}

