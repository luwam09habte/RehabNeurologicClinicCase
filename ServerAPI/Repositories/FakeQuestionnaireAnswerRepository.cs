using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakeQuestionnaireAnswerRepository : IQuestionnaireAnswerRepository
{
    private List<QuestionnaireAnswerModel> _answers = new();

    public void SubmitAnswer(QuestionnaireAnswerModel answerModel)
    {
        _answers.Add(answerModel);
    }
    public List<QuestionnaireAnswerModel> GetAll()
    {
        return _answers;
    }
}