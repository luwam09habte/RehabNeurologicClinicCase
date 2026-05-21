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


/*Til at redigere et eksisterende spørgeskema - mangler på QuestionnairePage*/

   /*  [HttpGet("assigned/{patientId}")]
    public ActionResult<List<Questionnaire>> GetAssignedQuestionnaires(int patientId)
    {
        var all = questionnaireRepository.GetQuestionnaires();

        var assigned = all
            .Where(q => q.AssignedToPatientIds.Contains(patientId))
            .ToList();

        return Ok(assigned);
    }*/
   
   /* Erstater den over*/
   
   

    /*
    [HttpPost("assign")]
    public IActionResult AssignQuestionnaire(int questionnaireId, int patientId)
    {
        var q = questionnaireRepository.GetById(questionnaireId);

        if (q == null)
            return NotFound("Spørgeskema findes ikke");

        if (!q.AssignedToPatientIds.Contains(patientId))
            q.AssignedToPatientIds.Add(patientId);

        questionnaireRepository.UpdateQuestionnaire(questionnaireId, q);

        return Ok(q);
    }
    
    [HttpPost("assign")]
    public IActionResult Assign([FromBody] QuestionnaireAnswerModel model)
    {
        model.IsCompleted = false;
        model.SubmittedAt = DateTime.MinValue;

        _repository.Create(model);

        return Ok(model);
    }
    
    [HttpGet("assigned/{patientId}")]
    public ActionResult<List<QuestionnaireAnswerModel>> GetAssigned(int patientId)
    {
        return Ok(_repository
            .GetByPatient(patientId)
            .Where(x => !x.IsCompleted)
            .ToList());
    }*/

