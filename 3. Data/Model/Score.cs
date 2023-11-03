namespace _3._Data.Model;

public class Score: ModelBase
{
    public string Type { get; set; }
    public string Date { get; set; }
    public string Result { get; set; }
    public string Status { get; set; }
    // public Student student
    public int StudentId { get; set; }
    public int TutorId { get; set; }
}