using Core.Models;

namespace ServerAPI.Interfaces;

// Kontrakt for spørgeskema-repository
// Alle repositories der implementerer dette interface skal have disse metoder
public interface IQuestionnaireRepository
{
    Questionnaire GetById(int id); // Henter ét spørgeskema ud fra dets id
    void CreateQuestionnaire(Questionnaire questionnaire); // Gemmer et nyt spørgeskema
    List<Questionnaire> GetQuestionnaires(); // Henter alle spørgeskemaer
}