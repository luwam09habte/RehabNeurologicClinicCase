using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/questionnaire")]
public class QuestionnaireController : ControllerBase
{
    private readonly IQuestionnaireRepository questionnaireRepository;

    public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
    {
        this.questionnaireRepository = questionnaireRepository;
    }
    

    [HttpGet("{id}")]
    public ActionResult<Questionnaire> GetById(int id)
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