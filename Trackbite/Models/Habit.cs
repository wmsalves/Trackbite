namespace Trackbite.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<HabitHistory> History { get; set; } = new List<HabitHistory>();
    }
}
