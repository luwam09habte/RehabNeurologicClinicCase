using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/questionnaireanswer")]
public class QuestionnaireAnswerController : ControllerBase
{
    private readonly IQuestionnaireAnswerRepository _repository;
    private readonly IQuestionnaireRepository _questionnaireRepository;

    
    public QuestionnaireAnswerController(
        IQuestionnaireAnswerRepository repository,
        IQuestionnaireRepository questionnaireRepository)
    {
        _repository = repository;
        _questionnaireRepository = questionnaireRepository;
    }

    [HttpPost("submit")]
    public ActionResult SubmitQuestionnaire([FromBody] QuestionnaireAnswerModel answerModel)
    {
        if (answerModel == null)
            return BadRequest();

        _repository.SubmitAnswer(answerModel);

        // FJERNER spørgeskema fra patientens tildelte liste
        _questionnaireRepository.MarkAsAnswered(answerModel.PatientId, answerModel.QuestionnaireId);

        return Ok();
    }

    [HttpGet]
    public ActionResult<List<QuestionnaireAnswerModel>> GetAll()
    {
        return Ok(_repository.GetAll());
    }


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