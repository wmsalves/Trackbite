using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackbite.Data;
using Trackbite.Models;

namespace Trackbite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HabitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Habits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
        {
            return await _context.Habits.ToListAsync();
        }
        // POST: api/Habits
        [HttpPost]
        public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
        {
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHabits", new { id = habit.Id }, habit);
        }
    }
}
