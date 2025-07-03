namespace CinemaSchedule.Core.Models
{
    public class Session
    {
        public int Id { get; set; }
        public DateTime ShowTime { get; set; }

        public int MovieId { get; set; }
    }
}
