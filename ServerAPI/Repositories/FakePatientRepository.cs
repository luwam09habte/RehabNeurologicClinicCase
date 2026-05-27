using System.Runtime.InteropServices.JavaScript;
using Core.Models;
using ServerAPI.Interfaces;

namespace ServerAPI.Repositories;

public class FakePatientRepository : IPatientRepository
{
    private List<Patient> fPatient =
    [
        new Patient() { PatientId = 1, Name = "Sebastian Hansen", Password = "Patient123", 
            Email = "sebkahr@gmail.com", PhoneNumber = "+45 60 46 88 03", InjuryType = "Slagtilfælde", InjuryDate = new DateTime(2019, 09, 19), Role = "Patient",
            Age = 22, Gender = "Mand"
        },
        new Patient() { PatientId = 2, Name = "Luwam Habte", Password = "Patient123", 
            Email = "luwam207@gmail.com", PhoneNumber = "+45 55 30 22 99",  InjuryType = "Covid-19", InjuryDate = new DateTime(2025, 06, 23), Role = "Patient",
            Age = 25, Gender = "Kvinde"
        },
        new Patient() { PatientId = 3, Name = "Michael Mikkelsen", Password = "Patient123", 
            Email = "michael259@gmail.com", PhoneNumber = "+45 88 82 10 66", InjuryType = "Slagtilfælde", InjuryDate = new DateTime(2014, 04, 21),Role = "Patient",
            Age = 40, Gender = "Mand"
        },
        new Patient() { PatientId = 4, Name = "Josefine Kristiansen", Password = "Patient123", 
            Email = "josefinek832@gmail.dk", PhoneNumber = "+45 32 45 76 12", InjuryType = "Hjernerystelse", InjuryDate = new DateTime(2015, 11, 29), Role = "Patient",
            Age = 55, Gender = "Kvinde"
        },
        new Patient() { PatientId = 5, Name = "Mads Frandsen", Password = "Patient123", 
            Email = "mads234@gmail.dk", PhoneNumber = "+45 55 41 85 03", InjuryType = "Slagtilfælde", InjuryDate = new DateTime(2009, 10, 03), Role = "Patient",
            Age = 29, Gender = "Mand"
        },
        new Patient() { PatientId = 6, Name = "Mogens Madsen", Password = "Patient123", 
            Email = "mogensm56@gmail.com", PhoneNumber = "+45 33 46 22 07", InjuryType = "Covid-19", InjuryDate = new DateTime(1995, 01, 26), Role = "Patient",
            Age = 66, Gender = "Mand"
        },
        new Patient() { PatientId = 7, Name = "Ole Jørgensen", Password = "Patient123", 
            Email = "Ole22@gmail.com", PhoneNumber = "+45 36 76 30 22", InjuryType = "TBI", InjuryDate = new DateTime(2023, 06, 13), Role = "Patient",
            Age = 78, Gender = "Mand"
        },
        new Patient() { PatientId = 8, Name = "Simone Nedergaard", Password = "Patient123", 
            Email = "Sim1918@gmail.com", PhoneNumber = "+45 37 82 02 42", InjuryType = "Hjernerystelse", InjuryDate = new DateTime(2005, 07, 06), Role = "Patient",
            Age = 33, Gender = "Kvinde"
        },
        new Patient() { PatientId = 9, Name = "Patrick Kjærsgaard", Password = "Patient123", 
            Email = "Pat05@outlook.com", PhoneNumber = "+45 28 44 92 19", InjuryType = "Covid-19", InjuryDate = new DateTime(2011, 05, 18), Role = "Patient",
            Age = 37, Gender = "Mand"
        },
        new Patient() { PatientId = 10, Name = "Kim Madsen", Password = "Patient123",
            Email = "kim1237@gmail.com", PhoneNumber = "+45 88 21 33 90", InjuryType = "Hjernerystelse", InjuryDate = new DateTime(2012, 04, 28),Role = "Patient",
            Age = 34, Gender = "Andet"
        }
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