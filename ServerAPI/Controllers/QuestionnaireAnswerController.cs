using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/answers")]
public class QuestionnaireAnswerController : ControllerBase
{
    private readonly IQuestionnaireAnswerRepository _repo;

    public QuestionnaireAnswerController(IQuestionnaireAnswerRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public IActionResult SaveAnswer([FromBody] QuestionnaireAnswer answer)
    {
        _repo.Save(answer);
        return Ok();
    }

    [HttpGet("{patientId}")]
    public ActionResult<List<QuestionnaireAnswer>> GetByPatient(int patientId)
    {
        return Ok(_repo.GetByPatient(patientId));
    }
}