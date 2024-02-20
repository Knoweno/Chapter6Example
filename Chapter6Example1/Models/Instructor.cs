using System.Collections.Generic;

namespace Chapter6Example1.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
