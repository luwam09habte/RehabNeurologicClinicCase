namespace Core.Models;
using MongoDB.Bson.Serialization.Attributes; // Bruges til MongoDB-attributter
 // Data skabelon

// ignorer ekstra felter, som C# modellen ikke kender
[BsonIgnoreExtraElements]
public class Questionnaire
{
    [BsonId] // DokumentId
    public int QuestionnaireId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int AdminId { get; set; }
    public List<string> InjuryTypes { get; set; } = new();
    // Liste over skadetyper spørgeskemaet passer til
    public List<Question> Questions { get; set; } = new();
    // Liste over spørgsmål i spørgeskemaet
}