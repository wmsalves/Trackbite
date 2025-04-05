using Microsoft.EntityFrameworkCore;
using Trackbite.Models;

namespace Trackbite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Habit> Habits => Set<Habit>();
        public DbSet<HabitHistory> HabitHistories => Set<HabitHistory>();

    }
}
