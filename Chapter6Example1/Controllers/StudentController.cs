using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chapter6Example1.Models;

namespace Chapter6Example1.Controllers
{
    public class StudentController : Controller
    {

        SchoolDbContext db;
        public StudentController(SchoolDbContext db)
        {
            this.db = db;

        }
        public async Task<IActionResult> AllStudent()
        {
            var student = await db.Students.ToListAsync();
            return View(student);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            db.Add(student);
            await db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }
        public async Task<IActionResult> EnrollCourse(int? id)
        {
            var course = await db.Courses.SingleOrDefaultAsync(i => i.CourseID == id);
            ViewBag.Course = course;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnrollCourse(Enrollment enrollment)
        {
            db.Add(enrollment);
            var course = await db.Courses.FindAsync(enrollment.CourseId);
            course.seatCapacity--;
            await db.SaveChangesAsync();
            return RedirectToAction("AllCourse","Course");
        }
        public async Task<IActionResult> AllClassmate(int? id)
        {
            var enrollCourse=await db.Enrollments.Where(
                e=>e.CourseId == id).ToListAsync();
            List<Student> classmate = new List<Student>();
            foreach (var e in enrollCourse)
            {
                var student = await db.Students.SingleOrDefaultAsync(s => s.StudentId == e.StudentId);
                classmate.Add(student); 
            }
            ViewData["Course"] = db.Courses.Find(id).CourseTitle;
            return View(classmate);
        }
    }
}
