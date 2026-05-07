using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private List<QuestionnaireAnswer> _answers = new();

    public void SubmitAnswer(QuestionnaireAnswer answer)
    {
        _answers.Add(answer);
    }
    public List<QuestionnaireAnswer> GetAll()
    {
        return _answers;
    }
}