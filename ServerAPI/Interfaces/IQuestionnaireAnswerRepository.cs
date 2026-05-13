using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireAnswerRepository
{
    void SubmitAnswer(QuestionnaireAnswerModel answerModel);
    List<QuestionnaireAnswerModel> GetAll();
}