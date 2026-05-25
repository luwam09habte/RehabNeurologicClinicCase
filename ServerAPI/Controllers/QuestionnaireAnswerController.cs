using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;
using ClosedXML.Excel;

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
    
    [HttpGet("export")]
    public IActionResult ExportToExcel()
    {
        var answers = _repository.GetAll();

        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add("Besvarelser");

        worksheet.Cell(1, 1).Value = "PatientId";
        worksheet.Cell(1, 2).Value = "QuestionnaireId";
        worksheet.Cell(1, 3).Value = "QuestionId";
        worksheet.Cell(1, 4).Value = "Svar";
        worksheet.Cell(1, 5).Value = "Dato";

        int row = 2;

        foreach (var answer in answers)
        {
            foreach (var q in answer.Answers)
            {
                worksheet.Cell(row, 1).Value = answer.PatientId;
                worksheet.Cell(row, 2).Value = answer.QuestionnaireId;
                worksheet.Cell(row, 3).Value = q.QuestionId;
                worksheet.Cell(row, 4).Value = q.SelectedOption;
                worksheet.Cell(row, 5).Value = answer.SubmittedAt;

                row++;
            }
        }

        using var stream = new MemoryStream();

        workbook.SaveAs(stream);

        var content = stream.ToArray();

        return File(
            content,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Besvarelser.xlsx");
    }
}