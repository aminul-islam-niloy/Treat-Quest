using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreatQuest.Data;
using TreatQuest.Models;

namespace TreatQuest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : Controller
    {
        private readonly QuizAppContext _context;

        public OptionsController(QuizAppContext context)
        {
            _context = context;
        }
        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
            return await _context.Options
                .Include(o => o.SubOptions)
                .ThenInclude(so => so.SubChoice)
                .ThenInclude(sc => sc.Prices)
                .ToListAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            var option = await _context.Options
                .Include(o => o.SubOptions)
                .ThenInclude(so => so.SubChoice)
                .ThenInclude(sc => sc.Prices)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
            _context.Options.Add(option);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = option.Id }, option);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> DeleteOptions(int id)
        {
            var option = await _context.Options
                .Include(o => o.SubOptions)
                .ThenInclude(so => so.SubChoice)
                .ThenInclude(sc => sc.Prices)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (option == null)
            {
                return NotFound();
            }

            _context.Options.Remove(option);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
