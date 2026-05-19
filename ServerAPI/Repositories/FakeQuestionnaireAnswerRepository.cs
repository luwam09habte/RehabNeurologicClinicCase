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

    public QuestionnaireAnswerModel GetById(int id)
    {
        throw new NotImplementedException();
    }
    
    public List<QuestionnaireAnswerModel> GetByPatient(int patientId)
    {
        throw new NotImplementedException();
    }
       
    public void UpdateQuestionnaire(int id, Questionnaire questionnaire)
    {
        throw new NotImplementedException();
    }
}