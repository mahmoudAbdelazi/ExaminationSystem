namespace ExaminationSystem.Models
{
    public class Choice : BaseModel
    {
        public string Text { get; set; } = null!;

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;

    }
}
