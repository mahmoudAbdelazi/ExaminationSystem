using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExaminationSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

        // DbSets (All Tables )
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentCourseRequest> StudentCourseRequests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
