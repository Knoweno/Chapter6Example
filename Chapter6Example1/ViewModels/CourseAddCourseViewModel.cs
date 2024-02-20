using Chapter6Example1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Chapter6Example1.ViewModels
{
    public class CourseAddCourseViewModel
    {
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public SelectList InstructorList { get; set; }
    }
}
