using HeroesWeb.Data;
using HeroesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HeroesWeb.Pages_SuperPoderes
{
    public class DetailsModel : PageModel
    {
        private readonly HeroesWeb.Data.HeroesContext _context;

        public DetailsModel(HeroesWeb.Data.HeroesContext context)
        {
            _context = context;
        }

        public SuperPoderes SuperPoderes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpoderes = await _context.SuperPoderes
                .Include(s => s.Heroe).FirstOrDefaultAsync(m => m.Id == id);
            if (superpoderes == null)
            {
                return NotFound();
            }
            else
            {
                SuperPoderes = superpoderes;
            }
            return Page();
        }
    }
}