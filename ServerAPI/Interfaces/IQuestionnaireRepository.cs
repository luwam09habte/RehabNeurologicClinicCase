using Core.Models;

namespace ServerAPI.Interfaces;

public interface IQuestionnaireRepository
{
    List<Questionnaire> GetQuestionnaires();
    Questionnaire GetById(int id);
    void CreateQuestionnaire(Questionnaire questionnaire);
    /*Til at redigere et eksisterende spørgeskema
    void UpdateQuestionnaire(int id, Questionnaire questionnaire);
    void MarkAsAnswered(int patientId, int questionnaireId);*/
}