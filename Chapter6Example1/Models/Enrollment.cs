using System.ComponentModel.DataAnnotations;

namespace Chapter6Example1.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollementId { get; set; }
        public int StudentId {  get; set; }
        public Student Student { get; set; }
        public int CourseId {  get; set; }
        public Course Course { get; set; }


    }
}
