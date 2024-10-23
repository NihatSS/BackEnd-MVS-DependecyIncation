using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB102App.Data;
using PB102App.Models;
using PB102App.ViewModels;

namespace PB102App.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
		{
			List<Work> works = await _context.Works.ToListAsync();
			List<Category> categories = await _context.Categories.Include(m=>m.Works).ToListAsync();
			List<Slider> sliders = await _context.Sliders.ToListAsync();
			HomeVM model = new()
			{
				Categories = categories,
				Works = works,
				Sliders = sliders
			};
			return View(model);
		}
	}
}
