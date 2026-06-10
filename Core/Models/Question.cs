namespace Core.Models;
// Data skabelon

public class Question
{
    public int QuestionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public List<string> Option { get; set; } = new();
    public int QuestionnaireId { get; set; }
    public string Label { get; set; } = string.Empty;
    public string Placeholder { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public string Type { get; set; } = "Scale5";
    // Spørgsmål starter som "Scale5" - altså 1-5 skala
}
