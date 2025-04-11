using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackbite.Data;

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
    }
}
