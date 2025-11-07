namespace ExaminationSystem.Models
{
    public class Course : BaseModel
    {

        public string Title { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public int Hours { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();

        public ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();


    }
}
