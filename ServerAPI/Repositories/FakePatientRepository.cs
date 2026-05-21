using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakePatientRepository : IPatientRepository
{
    private List<Patient> fPatient =
    [
        new Patient() { PatientId = 1, Name = "Sebastian Hansen", Password = "Patient123", 
            Email = "sebkahr@gmail.com", PhoneNumber = "+45 60 46 88 03", InjuryType = "Slagtilfælde", Role = "Patient" },
        new Patient() { PatientId = 2, Name = "Luwam Habte", Password = "Patient123", 
            Email = "luwam207@gmail.com", PhoneNumber = "+45 55 30 22 99",  InjuryType = "Covid-19", Role = "Patient" },
        new Patient() { PatientId = 3, Name = "Michael Mikkelsen", Password = "Patient123", 
            Email = "michael259@gmail.com", PhoneNumber = "+45 88 82 10 66", InjuryType = "Slagtilfælde", Role = "Patient" },
        new Patient() { PatientId = 4, Name = "Josefine Kristiansen", Password = "Patient123", 
            Email = "josefinek832@gmail.dk", PhoneNumber = "+45 32 45 76 12", InjuryType = "Hjernerystelse", Role = "Patient" },
        new Patient() { PatientId = 5, Name = "Mads Frandsen", Password = "Patient123", 
            Email = "mads234@gmail.dk", PhoneNumber = "+45 55 41 85 03", InjuryType = "Slagtilfælde", Role = "Patient" },
        new Patient() { PatientId = 6, Name = "Mogens Madsen", Password = "Patient123", 
            Email = "mogensm56@gmail.com", PhoneNumber = "+45 33 46 22 07", InjuryType = "Covid-19", Role = "Patient" },
        new Patient() { PatientId = 7, Name = "Ole Jørgensen", Password = "Patient123", 
            Email = "Ole22@gmail.com", PhoneNumber = "+45 36 76 30 22", InjuryType = "TBI", Role = "Patient" },
        new Patient() { PatientId = 8, Name = "Simone Nedergaard", Password = "Patient123", 
            Email = "Sim1918@gmail.com", PhoneNumber = "+45 37 82 02 42", InjuryType = "Hjernerystelse", Role = "Patient" },
        new Patient() { PatientId = 9, Name = "Patrick Kjærsgaard", Password = "Patient123", 
            Email = "Pat05@outlook.com", PhoneNumber = "+45 28 44 92 19", InjuryType = "Covid-19", Role = "Patient" },
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