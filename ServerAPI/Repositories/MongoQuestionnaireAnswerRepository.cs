using Core.Models;
using MongoDB.Driver;
using ServerAPI.Interfaces;


public class MongoQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private readonly IMongoCollection<QuestionnaireAnswerModel> _collection;

    public MongoQuestionnaireAnswerRepository(IConfiguration config)
    {
        var client = new MongoClient(config["Mongo:ConnectionString"]);
        var db = client.GetDatabase(config["Mongo:Database"]);
        _collection = db.GetCollection<QuestionnaireAnswerModel>("answers");
    }

    // GENERER NYT ID
    private int GetNextId()
    {
        var all = _collection.Find(_ => true).ToList();
        return all.Count == 0 ? 1 : all.Max(x => x.Id) + 1;
    }

    // ASSIGN (opretter et nyt dokument)
    public void Assign(QuestionnaireAnswerModel assignment)
    {
        assignment.Id = GetNextId();
        assignment.IsCompleted = false;
        assignment.SubmittedAt = DateTime.MinValue;
        assignment.UpdatedAt = DateTime.UtcNow;

        _collection.InsertOne(assignment);
    }

    // SUBMIT (opdaterer eksisterende dokument)
    public void SubmitAnswer(QuestionnaireAnswerModel answer)
    {
        answer.IsCompleted = true;
        answer.SubmittedAt = DateTime.UtcNow;
        answer.UpdatedAt = DateTime.UtcNow;

        _collection.ReplaceOne(x => x.Id == answer.Id, answer);
    }

    // GET ALL
    public List<QuestionnaireAnswerModel> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    // GET BY ID
    public QuestionnaireAnswerModel GetById(int id)
    {
        return _collection.Find(a => a.Id == id).FirstOrDefault();
    }

    // GET BY PATIENT
    public List<QuestionnaireAnswerModel> GetByPatient(int patientId)
    {
        return _collection.Find(a => a.PatientId == patientId).ToList();
    }

    // GET ASSIGNED (ikke besvaret)
    public List<QuestionnaireAnswerModel> GetAssigned(int patientId)
    {
        return _collection.Find(x => x.PatientId == patientId && !x.IsCompleted).ToList();
    }

    // GET HISTORY (besvaret)
    public List<QuestionnaireAnswerModel> GetHistory(int patientId)
    {
        return _collection.Find(x => x.PatientId == patientId && x.IsCompleted).ToList();
    }
}