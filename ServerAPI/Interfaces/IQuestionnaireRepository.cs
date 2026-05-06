using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireRepository
{
    List<Questionnaire> GetQuestionnaires();
    Questionnaire GetById(int id);
}