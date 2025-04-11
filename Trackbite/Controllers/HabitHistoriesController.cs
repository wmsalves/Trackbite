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

        // GET: api/habithistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitHistory>>> GetAllHabitHistories()
        {
            return await _context.HabitHistories
                .Include(h => h.Habit)
                .ToListAsync();
        }

        // GET: api/habithistories/byhabit/1
        [HttpGet("byhabit/{habitId}")]
        public async Task<ActionResult<IEnumerable<HabitHistory>>> GetByHabit(int habitId)
        {
            return await _context.HabitHistories
                .Where(h => h.HabitId == habitId)
                .ToListAsync();
        }

        // PUT: api/habithistories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitHistory(int id, HabitHistory habitHistory)
        {
            if (id != habitHistory.Id)
            {
                return BadRequest("ID do parâmetro não bate com o ID do corpo.");
            }

            var exists = await _context.HabitHistories.AnyAsync(h => h.Id == id);
            if (!exists)
            {
                return NotFound("Histórico não encontrado.");
            }

            _context.Entry(habitHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Erro ao atualizar o banco de dados.");
            }

            return NoContent();
        }

        // DELETE: api/habithistories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitHistory(int id)
        {
            var habitHistory = await _context.HabitHistories.FindAsync(id);
            if (habitHistory == null)
            {
                return NotFound();
            }

            _context.HabitHistories.Remove(habitHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
