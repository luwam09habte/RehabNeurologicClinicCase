using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/questionnaire")]
public class QuestionnaireController : ControllerBase
{
    private readonly IQuestionnaireRepository questionnaireRepository;
    
    // Constructor
    public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
    {
        this.questionnaireRepository = questionnaireRepository;
    }

// Henter data så Admin kan se en patients besvarelser og den bruger questionnaireId til at hente spørgeskemaet og illustrere de besvarelser der er lavet
    [HttpGet("{id}")]
    public ActionResult<Questionnaire> GetQuestionnaireById(int id)
    {
        var questionnaire = questionnaireRepository.GetById(id);

        if (questionnaire == null)
            return NotFound();

        return Ok(questionnaire);
    }

    [HttpPost]
    public IActionResult CreateQuestionnaire(Questionnaire questionnaire)
    {
        questionnaireRepository.CreateQuestionnaire(questionnaire);

        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Questionnaire>> GetQuestionnaires()
    {
        return Ok(questionnaireRepository.GetQuestionnaires());
    }
}

