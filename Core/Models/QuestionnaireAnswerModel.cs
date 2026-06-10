using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
// Data skabelon

namespace Core.Models;

// Rykkede enum til sin egen klasse

public class QuestionnaireAnswerModel
{
    [BsonId] // DokumentId for besvarelser
    public int Id { get; set; }
    public int PatientId { get; set; } = 0;
    public int QuestionnaireId { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.Now;
    // Hvornår besvarelsen blev sendt
    public FollowUpType FollowUpType { get; set; }
    public List<QuestionAnswer> Answers { get; set; } = new();
    // Listen med patientens svar$
    public bool IsCompleted { get; set; } = false;
    // Om besvarelsen er færdig
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
// Hvornår dokumentet sidst blev opdateret.
}