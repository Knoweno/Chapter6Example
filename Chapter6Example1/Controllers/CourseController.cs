using Chapter6Example1.Models;
using Chapter6Example1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chapter6Example1.Controllers
{
    public class CourseController : Controller
    {
        SchoolDbContext db;
        public CourseController(SchoolDbContext db)
        {
            this.db = db;

        }
        public async Task<IActionResult> AllCourse()
        {
            var courrse = await db.Courses.Include(c=>c.Instructor).ToListAsync();
            return View(courrse);
        }

        public async Task<IActionResult> AddCourse()
        {
            var instructorDisplay = await db.Instructors.Select(
                x => new { Id = x.InstructorId, value = x.InstructorName }).ToListAsync();
            CourseAddCourseViewModel vm = new CourseAddCourseViewModel();
            vm.InstructorList = new SelectList(instructorDisplay, "Id", "valie");
            return View(vm);
        }

    }
}
