namespace ASP_Lesson_17.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; } = new();
    }
}
