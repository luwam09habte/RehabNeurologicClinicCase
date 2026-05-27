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
    private readonly IPatientRepository _patientRepository;

    public QuestionnaireAnswerController(IQuestionnaireAnswerRepository repository,
        IPatientRepository patientRepository)
    {
        _repository = repository;
        _patientRepository = patientRepository;
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
    
        // EKSPORT TIL EXCEL 
        [HttpGet("export")]
        public IActionResult ExportToExcel(
            string? searchText,
            string? injuryType,
            string? gender,
            int? minAge,
            int? maxAge,
            bool? completed)
        {
            // HENT data
            var answers = _repository.GetAll()
                .Where(x => x.Answers != null && x.Answers.Any())
                .ToList();
            var patients = _patientRepository.GetAll();

            // FILTER 
            var filtered = answers.Where(x =>
            {
                if (completed.HasValue && x.IsCompleted != completed.Value)
                    return false;

                return true;
            }).ToList();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Besvarelser");

            // HEADERS
            worksheet.Cell(1, 1).Value = "Navn";
            worksheet.Cell(1, 2).Value = "Køn";
            worksheet.Cell(1, 3).Value = "Skadetype";
            worksheet.Cell(1, 4).Value = "Alder";
            worksheet.Cell(1, 5).Value = "QuestionnaireId";
            worksheet.Cell(1, 6).Value = "FollowUpType";
            worksheet.Cell(1, 7).Value = "QuestionId";
            worksheet.Cell(1, 8).Value = "Svar";
            worksheet.Cell(1, 9).Value = "Dato";
            worksheet.Cell(1, 10).Value = "Status";

            worksheet.Row(1).Style.Font.Bold = true;

            int row = 2;

            // LOOP IGENNEM SVAR OG UDFYLD EXCEL
            foreach (var answer in filtered)
            {
                var patient = patients.FirstOrDefault(p => p.PatientId == answer.PatientId);

                foreach (var q in answer.Answers)
                {
                    worksheet.Cell(row, 1).Value = patient?.Name;
                    worksheet.Cell(row, 2).Value = patient?.Gender;
                    worksheet.Cell(row, 3).Value = patient?.InjuryType;
                    worksheet.Cell(row, 4).Value = patient?.Age;

                    worksheet.Cell(row, 5).Value = answer.QuestionnaireId;
                    worksheet.Cell(row, 6).Value = answer.FollowUpType.ToString();

                    worksheet.Cell(row, 7).Value = q.QuestionId;
                    worksheet.Cell(row, 8).Value = q.SelectedOption; // Her er svaret

                    worksheet.Cell(row, 9).Value = answer.SubmittedAt.ToString("dd-MM-yyyy");

                    worksheet.Cell(row, 10).Value =
                        answer.IsCompleted ? "Afsluttet" : "Aktiv";

                    row++;
                }
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Besvarelser.xlsx");
        }
    }