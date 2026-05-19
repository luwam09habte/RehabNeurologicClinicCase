namespace Core.Models;
using MongoDB.Bson.Serialization.Attributes;

public class Questionnaire
{
    [BsonId]
    public int QuestionnaireId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public List<Question> Questions { get; set; } = new();

    public int AdminId { get; set; }
    /* For injurytype men bliver ikke taget fat i*/
    public List<string> InjuryTypes { get; set; } = new();
    
    /*Så det kan tildelses på patientID*/
    public List<int> AssignedToPatientIds { get; set; } = new();
    
    /* Måske den her - public DateTime CreatedAt { get; set; }*/
}