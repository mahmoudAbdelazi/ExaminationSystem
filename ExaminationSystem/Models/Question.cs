using ExaminationSystem.Models.Enums;

namespace ExaminationSystem.Models
{
    public class Question : BaseModel
    {
        public string Text { get; set; } = null!;

        public QuestionLevel questionLevel { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;

        public ICollection<Choice> Choices { get; set; } = new HashSet<Choice>();

        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new HashSet<ExamQuestion>();

    }
}
