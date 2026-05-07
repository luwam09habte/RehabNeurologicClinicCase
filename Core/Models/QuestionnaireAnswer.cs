namespace Core.Models;

public class QuestionnaireAnswer
{
    public int AnswerId { get; set; }
    public int PatientId { get; set; }
    public int QuestionnaireId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;

    public List<QuestionAnswer> Answers { get; set; }
}