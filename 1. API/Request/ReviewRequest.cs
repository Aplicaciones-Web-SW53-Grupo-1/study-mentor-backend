using System.ComponentModel.DataAnnotations;

namespace _1._API.Request;

public class ReviewRequest
{
    [Required]
    public string review { get;set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    public int StudentId { get; set; }
}