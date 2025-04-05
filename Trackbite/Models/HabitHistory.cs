namespace Trackbite.Models
{
    public class HabitHistory
    {
        public int Id { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
