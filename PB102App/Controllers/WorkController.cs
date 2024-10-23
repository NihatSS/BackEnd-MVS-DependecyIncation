using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;

namespace PB102App.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _context;

        public WorkController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Work> work = await _context.Works.ToListAsync();
            return View(work);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();
            Work work = await _context.Works.Include(m=>m.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (work == null) return NotFound();
            return View(work);
        }
    }
}
