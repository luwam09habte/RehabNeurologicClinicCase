using Core.Models;
using MongoDB.Driver;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class MongoQuestionnaireRepository : IQuestionnaireRepository
{
    private readonly IMongoCollection<Questionnaire> _collection;

    public MongoQuestionnaireRepository(IConfiguration config)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var db = client.GetDatabase(config["Mongo:Database"]);

        _collection = db.GetCollection<Questionnaire>("questionnaires");
    }

    public Questionnaire GetById(int id)
    {
        return _collection
            .Find(q => q.QuestionnaireId == id)
            .FirstOrDefault();
    }
    
    // Giver hvert spørgeskema et unikt ID
    public void CreateQuestionnaire(Questionnaire questionnaire)
    {
        int newId = 1;

        var all = _collection.Find(_ => true).ToList();

        foreach (var q in all)
        {
            if (q.QuestionnaireId >= newId)
                newId = q.QuestionnaireId + 1;
        }

        questionnaire.QuestionnaireId = newId;
        
        // Giver hvert spørgsmål et unikt ID
        int questionId = 1;
        foreach (var question in questionnaire.Questions)
        {
            question.QuestionId = questionId;
            questionId++;
        }
        
        _collection.InsertOne(questionnaire);
    }
    
    public List<Questionnaire> GetQuestionnaires()
    {
        return _collection.Find(_ => true).ToList();
    }
    
    /*Til at redigere et eksisterende spørgeskema - mangler på QuestionnairePage*/
    public void UpdateQuestionnaire(int id, Questionnaire questionnaire)
    {
        _collection.ReplaceOne(q => q.QuestionnaireId == id, questionnaire);
    }
    
    /*Så spørgeskema forsvinder når en patient har svaret*/

    public void MarkAsAnswered(int patientId, int questionnaireId)
    {
        var q = _collection.Find(x => x.QuestionnaireId == questionnaireId).FirstOrDefault();
        if (q == null) return;

        q.AssignedToPatientIds.Remove(patientId);

        _collection.ReplaceOne(x => x.QuestionnaireId == questionnaireId, q);
    }
}