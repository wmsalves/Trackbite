﻿using Microsoft.AspNetCore.Http;
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

        // GET: api/habits/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Habit>> GetHabit(int id)
        {
            var habit = await _context.Habits.FindAsync(id);

            if (habit == null)
            {
                return NotFound();
            }

            return habit;
        }

        // POST: api/Habits
        [HttpPost]
        public async Task<ActionResult<Habit>> CreateHabit(Habit habit)
        {
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetHabits", new { id = habit.Id }, habit);
        }

        // PUT: api/habits/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabit(int id, Habit habit)
        {
            if (id != habit.Id)
            {
                return BadRequest();
            }

            _context.Entry(habit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Habits.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/habits/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabit(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }

            _context.Habits.Remove(habit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
