using Core.Models;
using MongoDB.Driver;
using ServerAPI.Interfaces;
using MongoDB.Bson.Serialization;

public class MongoQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private readonly IMongoCollection<QuestionnaireAnswer> _collection;

    public MongoQuestionnaireAnswerRepository(IConfiguration config)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var db = client.GetDatabase(config["Mongo:Database"]);
        _collection = db.GetCollection<QuestionnaireAnswer>("answers");
    }

    public void SubmitAnswer(QuestionnaireAnswer answer)
    {
        _collection.InsertOne(answer);
    }

    public List<QuestionnaireAnswer> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }
}