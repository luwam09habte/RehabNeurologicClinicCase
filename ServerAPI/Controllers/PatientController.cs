using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Interfaces;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/patient")]
public class PatientController : ControllerBase
{
    private IPatientRepository FakePatientRepository;

    // Dependency injection. Constructor til funktionen ovenfor
    public PatientController(IPatientRepository patientRepository)
    {
        this.FakePatientRepository = patientRepository;
    }

    [HttpGet]
    public Patient[] GetAll()
    {
        return FakePatientRepository.GetAll();
    }

    [HttpPost("Validate")]
    public ActionResult<Patient> Validate(string email, string password)
    {
        var patient = FakePatientRepository.Validate(email, password);

        if (patient == null)
            return NotFound();

        return Ok(patient);
    }
}