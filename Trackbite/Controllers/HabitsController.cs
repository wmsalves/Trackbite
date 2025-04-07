using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trackbite.Data;

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
    }
}
