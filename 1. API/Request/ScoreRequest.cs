using Microsoft.Build.Framework;

namespace _1._API.Request;

public class ScoreRequest
{
    [Required]
    public string Type { get; set; }
    [Required]
    public string Date { get; set; }
    [Required]
    public string Score { get; set; }
    [Required]
    public string Status { get; set; }
    // public Student student
    [Required]
    public int StudentId { get; set; }
    // public Tutor tutor
    [Required]
    public int TutorId { get; set; }
}