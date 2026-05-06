using Core.Models;
namespace ServerAPI.Interfaces;

// Constructor med en masse hard coded data til spørgeskema
public class FQuestionnaireRepo : IQuestionnaireRepository
{
    private List<Questionnaire> _questionnaires;

    public FQuestionnaireRepo()
    {
        _questionnaires = new List<Questionnaire>
        {
            new Questionnaire
            {
                QuestionnaireId = 1,
                Title = "Træthedsevaluering",
                Questions = new List<Question>
                {
                    new Question
                    {
                        QuestionId = 1,
                        Text = "Jeg er generet af min træthed",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 2,
                        Text = "Jeg bliver hurtigt træt og udmattet",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 3,
                        Text = "Jeg foretager mig ikke særlig meget i løbet af dagen",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 4,
                        Text = "Jeg har ikke energi nok i løbet af dagen",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 5,
                        Text = "Jeg føler mig fysisk udmattet",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 6,
                        Text = "Jeg har svært ved at sætte gøremål i gang",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 7,
                        Text = "Jeg har svært ved at tænke klart",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 8,
                        Text = "Jeg har ikke lyst til at foretage mig noget",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 9,
                        Text = "Jeg føler mig mentalt træt og udmattet",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    },
                    new Question
                    {
                        QuestionId = 10,
                        Text = "Jeg har svært ved at koncentrere mig",
                        Option = new List<string> { "1", "2", "3", "4", "5" }
                    }
                }
            }
        };
    }
    public List<Questionnaire> GetQuestionnaires()
    {
        return _questionnaires;
    }

    public Questionnaire GetById(int id)
    {
        return _questionnaires.FirstOrDefault(q => q.QuestionnaireId == id);
    }
}

