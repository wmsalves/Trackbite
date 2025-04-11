using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trackbite.Data;
using Trackbite.Models;

namespace Trackbite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitHistoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HabitHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/habithistories
        [HttpPost]
        public async Task<ActionResult<HabitHistory>> CreateHabitHistory(HabitHistory habitHistory)
        {
            // Verifica se o hábito associado existe
            var habitExists = await _context.Habits.AnyAsync(h => h.Id == habitHistory.HabitId);
            if (!habitExists)
            {
                return BadRequest("Hábito associado não encontrado.");
            }

            _context.HabitHistories.Add(habitHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHabitHistoryById), new { id = habitHistory.Id }, habitHistory);
        }

        // GET: api/habithistories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<HabitHistory>> GetHabitHistoryById(int id)
        {
            var habitHistory = await _context.HabitHistories.FindAsync(id);

            if (habitHistory == null)
            {
                return NotFound();
            }

            return habitHistory;
        }
    }
}
