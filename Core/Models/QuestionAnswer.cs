namespace Core.Models;

public class QuestionAnswer
{
    public int QuestionId { get; set; }
    /* Hvis de skal kunne skrive fri tekst - public List<string> SelectedOptions { get; set; } = new();*/
    public string SelectedOption { get; set; }
}

