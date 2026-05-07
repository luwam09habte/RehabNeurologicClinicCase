using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireAnswerRepository
{
    void SubmitAnswer(QuestionnaireAnswer answer);
    List<QuestionnaireAnswer> GetAll();
}