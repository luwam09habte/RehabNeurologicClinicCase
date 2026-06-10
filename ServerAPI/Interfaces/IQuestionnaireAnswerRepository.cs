using Core.Models;

namespace ServerAPI.Interfaces;

// Kontrakt for spørgeskema Svar-repository
// Alle repositories der implementerer dette interface skal have disse metoder
public interface IQuestionnaireAnswerRepository
{
    List<QuestionnaireAnswerModel> GetAll(); // // Henter alle tildelinger/besvarelser
    QuestionnaireAnswerModel GetById(int id); // Henter én besvarelse/tildeling ud fra id
    void SubmitAnswer(QuestionnaireAnswerModel answerModel); // Opdaterer en tildeling med patientens svar
    List<QuestionnaireAnswerModel> GetByPatient(int patientId); // Henter alle besvarelser for én patient
    List<QuestionnaireAnswerModel> GetAssigned(int patientId); // Henter spørgeskemaer der er tildelt patienten, men ikke besvaret
    List<QuestionnaireAnswerModel> GetHistory(int patientId); // Henter patientens tidligere/gennemførte besvarelser
    void Assign(QuestionnaireAnswerModel assignment); // Opretter en ny tildeling af et spørgeskema til en patient
} 