using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class QuestionnaireAnswerModel
{
    [BsonId]
    /*[BsonElement("_id")]  Måske den skal være der*/ 
    public int Id { get; set; }
    public int PatientId { get; set; } = 0;
    public int QuestionnaireId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;

    public List<QuestionAnswer> Answers { get; set; } = new();
    public string FollowUpType { get; set; } = "before"; // before, after, 3m, 6m
    
    public bool IsCompleted { get; set; } = false;
    
    
    //bedrings score//
    public int Score { get; set; }
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}