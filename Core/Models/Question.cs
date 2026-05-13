namespace Core.Models;

public class Question
{
    public int QuestionId { get; set; }

    public string Text { get; set; } = string.Empty;

    public List<string> Option { get; set; } = new();
    
    public int QuestionnaireId { get; set; }
    
    /* Så spørgsmål svar er krævet*/
    public bool IsRequired { get; set; } 
    
    /* For at vælge flere valgmuligheder?*/
    public string Type { get; set; } = "MultipleChoice";
}