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

    // TILDEL SPØRGESKEMA
    [HttpPost("assign")]
    public IActionResult Assign([FromBody] QuestionnaireAnswerModel model)
    {
        if (model == null)
            return BadRequest("Model is null");

        model.IsCompleted = false;
        model.SubmittedAt = DateTime.MinValue;

        _repository.Assign(model);

        return Ok(model);
    }

    // HENT TILDELTE (ikke besvaret)
    [HttpGet("assigned/{patientId}")]
    public ActionResult<List<QuestionnaireAnswerModel>> GetAssigned(int patientId)
    {
        return Ok(_repository.GetAssigned(patientId));
    }

    // HENT HISTORIK (besvaret)
    [HttpGet("history/{patientId}")]
    public ActionResult<List<QuestionnaireAnswerModel>> GetHistory(int patientId)
    {
        return Ok(_repository.GetHistory(patientId));
    }

    // SUBMIT SVAR
    [HttpPost("submit")]
    public IActionResult Submit([FromBody] QuestionnaireAnswerModel model)
    {
        if (model == null)
            return BadRequest();

        _repository.SubmitAnswer(model);

        return Ok();
    }

    // HENT ALLE SVAR
    [HttpGet]
    public ActionResult<List<QuestionnaireAnswerModel>> GetAll()
    {
        return Ok(_repository.GetAll());
    }

    // HENT ALLE SVAR FOR SAMME PATIENT
    [HttpGet("{answerId}/patientanswers")]
    public ActionResult<List<QuestionnaireAnswerModel>> GetAllAnswersForSamePatient(int answerId)
    {
        var answer = _repository.GetById(answerId);

        if (answer == null)
            return NotFound($"Answer with ID {answerId} not found");

        var patientAnswers = _repository.GetByPatient(answer.PatientId);

        return Ok(patientAnswers);
    }
}