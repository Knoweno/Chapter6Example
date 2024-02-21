namespace Chapter6Example1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
