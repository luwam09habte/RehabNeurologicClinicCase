using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public enum FollowUpType
{
    FørBehandling,
    EfterBehandling,
    TreMånederEfter,
    SeksMånederEfter
}

public class QuestionnaireAnswerModel
{
    [BsonId]
    /*[BsonElement("_id")]  Måske den skal være der*/ 
    public int Id { get; set; }
    public int PatientId { get; set; } = 0;
    public int QuestionnaireId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
    public FollowUpType FollowUpType { get; set; }
    public List<QuestionAnswer> Answers { get; set; } = new();
    public bool IsCompleted { get; set; } = false;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}