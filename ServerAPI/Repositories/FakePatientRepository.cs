using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakePatientRepository : IPatientRepository
{
    private List<Patient> fPatient =
    [
        new Patient() { PatientId = 1, Name = "Patient1", Password = "Patient123", Email = "Patient1", Role = "Patient" },
        new Patient() { PatientId = 2, Name = "Patient2", Password = "Patient123", Email = "Patient2", Role = "Patient" }
    ];

    public Patient[] GetAll()
    {
        return fPatient.ToArray();
    }

    public Patient? Validate(string email, string password)
    {
        foreach (Patient u in fPatient)
            if (u.Email == email && u.Password == password)
            {
                return u;
            }

        return null;
    }
}