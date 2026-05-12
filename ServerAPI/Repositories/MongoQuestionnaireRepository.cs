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

        _collection.InsertOne(questionnaire);
    }
    
    public List<Questionnaire> GetQuestionnaires()
    {
        return _collection.Find(_ => true).ToList();
    }
    
}