using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/questionnaireanswer")]
public class QuestionnaireAnswerController : ControllerBase
{
    private readonly IQuestionnaireAnswerRepository _repository;

    public QuestionnaireAnswerController(IQuestionnaireAnswerRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("submit")]
    public ActionResult SubmitQuestionnaire([FromBody] QuestionnaireAnswer answer)
    {
        if (answer == null)
            return BadRequest();

        _repository.SubmitAnswer(answer);

        return Ok();
    }
    
    [HttpGet]
    public ActionResult<List<QuestionnaireAnswer>> GetAll()
    {
        return Ok(_repository.GetAll());
    }
}