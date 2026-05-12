namespace Core.Models;
using MongoDB.Bson.Serialization.Attributes;

public class Questionnaire
{
    [BsonId]
    public int QuestionnaireId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public List<Question> Questions { get; set; } = new();

    public int PatientId { get; set; }
}