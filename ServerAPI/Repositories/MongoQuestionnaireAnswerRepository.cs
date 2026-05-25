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
        answer.SubmittedAt = DateTime.UtcNow;
        answer.UpdatedAt = DateTime.UtcNow;
        answer.IsCompleted = false; // ✅ ikke afsluttet endnu

        // ✅ 1. opdater svar (assignment bliver til besvaret)
        _collection.ReplaceOne(x => x.Id == answer.Id, answer);

        // ✅ 2. hent alle svar for samme patient + questionnaire
        var all = _collection.Find(x =>
                x.PatientId == answer.PatientId &&
                x.QuestionnaireId == answer.QuestionnaireId &&
                x.SubmittedAt != DateTime.MinValue // kun besvarede
        ).ToList();

        // ✅ 3. tjek om alle 4 findes
        bool completed =
            all.Any(x => x.FollowUpType == FollowUpType.FørBehandling) &&
            all.Any(x => x.FollowUpType == FollowUpType.EfterBehandling) &&
            all.Any(x => x.FollowUpType == FollowUpType.TreMånederEfter) &&
            all.Any(x => x.FollowUpType == FollowUpType.SeksMånederEfter);

        // ✅ 4. opdater ALLE hvis færdig
        if (completed)
        {
            var filter = Builders<QuestionnaireAnswerModel>.Filter.Where(x =>
                x.PatientId == answer.PatientId &&
                x.QuestionnaireId == answer.QuestionnaireId);

            var update = Builders<QuestionnaireAnswerModel>.Update
                .Set(x => x.IsCompleted, true);

            _collection.UpdateMany(filter, update);
        }
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