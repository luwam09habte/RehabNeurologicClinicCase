using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("/api/questionnaire")]
public class QuestionnaireController : ControllerBase
{
    private IQuestionnaireRepository FakeQuestionnaireRepository;
    
    public 
}