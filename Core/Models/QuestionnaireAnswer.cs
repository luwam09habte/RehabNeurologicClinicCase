using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class QuestionnaireAnswer
{
    [BsonId]
    public int Id { get; set; }
    
    public int PatientId { get; set; }
    public int QuestionnaireId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;

    public List<QuestionAnswer> Answers { get; set; }
}