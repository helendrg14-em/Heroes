using HeroesWeb.Data;
using HeroesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HeroesWeb.Pages_SuperPoderes
{
    public class DeleteModel : PageModel
    {
        private readonly HeroesWeb.Data.HeroesContext _context;

        public DeleteModel(HeroesWeb.Data.HeroesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SuperPoderes SuperPoderes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpoderes = await _context.SuperPoderes
                .Include(s => s.Heroe)
                .FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superpoderes = await _context.SuperPoderes.FindAsync(id);
            if (superpoderes != null)
            {
                SuperPoderes = superpoderes;
                _context.SuperPoderes.Remove(SuperPoderes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}