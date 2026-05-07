using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireAnswerRepository
{
    void Save(QuestionnaireAnswer answer);
    List<QuestionnaireAnswer> GetByPatient(int patientId);
}