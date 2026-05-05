using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakePatientRepository : IPatientRepository
{
    private List<Patient> fPatient =
    [
        new Patient() { PatientId = 1, Name = "Patient1", Password = "Peter123", Email = "Peter123@gmail.com", Role = "Patient" },
        new Patient() { PatientId = 2, Name = "Patient2", Password = "Lars123", Email = "Lars123@gmail.com", Role = "Patient" }
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