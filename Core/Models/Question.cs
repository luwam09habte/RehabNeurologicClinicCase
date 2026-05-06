namespace Core.Models;

public class Question
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public List<string> Option { get; set; }
    public int QuestionnaireId { get; set; }
}