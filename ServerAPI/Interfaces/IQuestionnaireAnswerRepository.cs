using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireAnswerRepository
{
    List<QuestionnaireAnswerModel> GetAll();
    QuestionnaireAnswerModel GetById(int id);
    void SubmitAnswer(QuestionnaireAnswerModel answerModel);
    List<QuestionnaireAnswerModel> GetByPatient(int patientId);
    List<QuestionnaireAnswerModel> GetAssigned(int patientId);
    List<QuestionnaireAnswerModel> GetHistory(int patientId);
    public void Assign(QuestionnaireAnswerModel assignment);
}