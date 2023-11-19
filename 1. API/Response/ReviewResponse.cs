namespace _1._API.Response
{
    public class ReviewResponse
    {
        public string TextMessage { get; set; }
        public int Rating { get; set; }
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public DateTime Date { get; set; }
    }
}