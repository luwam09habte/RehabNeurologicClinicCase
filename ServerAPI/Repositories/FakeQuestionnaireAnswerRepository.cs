using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private List<QuestionnaireAnswer> _answers = new();

    public void Save(QuestionnaireAnswer answer)
    {
        answer.AnswerId = _answers.Count + 1;
        _answers.Add(answer);
    }

    public List<QuestionnaireAnswer> GetByPatient(int patientId)
    {
        return _answers.Where(a => a.PatientId == patientId).ToList();
    }
}