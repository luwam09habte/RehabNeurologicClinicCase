namespace Core.Models;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Questionnaire
{
    [BsonId]
    public int QuestionnaireId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int AdminId { get; set; }
    public List<string> InjuryTypes { get; set; } = new();
    public List<Question> Questions { get; set; } = new();
}