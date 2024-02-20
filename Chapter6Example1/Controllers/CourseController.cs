using Chapter6Example1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
