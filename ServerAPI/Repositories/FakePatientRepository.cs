using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakePatientRepository : IPatientRepository
{
    private List<Patient> fPatient =
    [
        new Patient() { PatientId = 1, Name = "Sebastian Kahr Hansen", Password = "Patient123", 
            Email = "Sebkahr@gmail.com", PhoneNumber = "+45 60 46 88 03", InjuryType = "Slagtilfælde", Role = "Patient" },
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