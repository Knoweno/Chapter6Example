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
            var course = await db.Courses.Include(c=>c.Instructor).ToListAsync();
            return View(course);
        }
        
        public async Task<IActionResult> AddCourse()
        {
            var instructorDisplay = await db.Instructors.Select(
                x => new { Id = x.InstructorId, value = x.InstructorName }).ToListAsync();
            CourseAddCourseViewModel vm = new CourseAddCourseViewModel();
            vm.InstructorList = new SelectList(instructorDisplay, "Id", "value");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseAddCourseViewModel vm)
        {
            var instructor = await db.Instructors.SingleOrDefaultAsync(i=>
            i.InstructorId == vm.Instructor.InstructorId);
            vm.Course.Instructor = instructor;
            db.Add(vm.Course);
            await db.SaveChangesAsync();
            return RedirectToAction("AllCourse");
        }
        

    }
}
