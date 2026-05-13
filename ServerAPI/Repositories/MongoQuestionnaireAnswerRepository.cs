using Core.Models;
using MongoDB.Driver;
using ServerAPI.Interfaces;
using MongoDB.Bson.Serialization;

public class MongoQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private readonly IMongoCollection<QuestionnaireAnswerModel> _collection;

    public MongoQuestionnaireAnswerRepository(IConfiguration config)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var db = client.GetDatabase(config["Mongo:Database"]);
        _collection = db.GetCollection<QuestionnaireAnswerModel>("answers");
    }

    public void SubmitAnswer(QuestionnaireAnswerModel answerModel)
    {
        int newId = 1;
        var alle = _collection.Find(_ => true).ToList();

        foreach (var a in alle)
        {
            if (a.Id >= newId)
                newId = a.Id + 1;
        }

        answerModel.Id = newId;
        _collection.InsertOne(answerModel);
    }

    public List<QuestionnaireAnswerModel> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }
}