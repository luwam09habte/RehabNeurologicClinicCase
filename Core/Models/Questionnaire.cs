namespace Core.Models;

public class Questionnaire
{
    public int QuestionnaireId { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public List<Question> Questions { get; set; }
    public int PatientId { get; set; }
}