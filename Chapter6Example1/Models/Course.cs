namespace Chapter6Example1.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseTitle { get; set; }
        public int seatCapacity { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<Enrollment> Enrollments { get;}
    }
}
