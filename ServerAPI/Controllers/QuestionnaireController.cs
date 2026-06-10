using Core.Models;
using Microsoft.AspNetCore.Mvc; // Giver adgang til controller-funktionalitet i ASP.NET fx. ok()
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController] // Fortæller ASP.NET, at denne klasse er en API-controller - betyder, at klassen kan modtage HTTP-requests og returnere HTTP-responses
[Route("api/questionnaire")] // Grundruten for controlleren
public class QuestionnaireController : ControllerBase // Opretter controllerklassen så klassen får adgang til API metoder som, ok()
{
    // Gemmer repository’et i controlleren : "readonly" = kan kun kan sættes én gang, typisk i constructoren
    private readonly IQuestionnaireRepository questionnaireRepository; 
    
    // Constructor - ASP.NET bruger dependency injection til at give controlleren et repository-objekt
    public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
    {
        // Gemmer det injectede repository i feltet, så controllerens metoder kan bruge det
        this.questionnaireRepository = questionnaireRepository;
    } 
    
    // Henter data så Admin kan se en patients besvarelser og den bruger questionnaireId til at hente spørgeskemaet og illustrere de besvarelser der er lavet
    [HttpGet("{id}")] // Reagerer på GET med et ID
    public ActionResult<Questionnaire> GetQuestionnaireById(int id) // int id kommer fra URL’en
    {
        var questionnaire = questionnaireRepository.GetById(id);

        if (questionnaire == null)
            return NotFound();

        return Ok(questionnaire);
    } // Retunerer enten et Questionnaire-objekt eller et HTTP-svar som NotFound

    
    [HttpPost] // Reagerer på POST
    // Metoden modtager et Questionnaire-objekt fra frontend. Frontend sender JSON, og ASP.NET laver det om til et C# Questionnaire-objekt
    public IActionResult CreateQuestionnaire(Questionnaire questionnaire)
    {
        // Controlleren kalder metoden gennem interfacet.
        questionnaireRepository.CreateQuestionnaire(questionnaire);

        return Ok();
    }

    [HttpGet] // Reagerer på GET
    // Metoden returnerer en liste af spørgeskemaer
    public ActionResult<List<Questionnaire>> GetQuestionnaires()
    {
        return Ok(questionnaireRepository.GetQuestionnaires());
    }
    // Controlleren beder repository’et hente alle spørgeskemaer og returnerer dem som JSON til frontend
}

