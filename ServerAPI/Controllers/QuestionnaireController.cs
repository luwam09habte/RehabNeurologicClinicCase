using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/questionnaire")]
public class QuestionnaireController : ControllerBase
{
    private IQuestionnaireRepository FakeQuestionnaireRepository;

    public QuestionnaireController(IQuestionnaireRepository questionnaireRepository)
    {
        this.FakeQuestionnaireRepository= questionnaireRepository;
    }

    [HttpGet]
    public ActionResult<List<Questionnaire>> GetQuestionnaires()
    {
        return Ok(FakeQuestionnaireRepository.GetQuestionnaires());
    }
    
    [HttpGet("{id}")]
    public ActionResult<Questionnaire> GetById(int id)
    {
        var questionnaire = FakeQuestionnaireRepository.GetById(id);
        if (questionnaire == null)
            return NotFound();
        return Ok(questionnaire);
    }
}