using HeroesWeb.Data;
using HeroesWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HeroesWeb.Pages_SuperPoderes
{
    public class IndexModel : PageModel
    {
        private readonly HeroesWeb.Data.HeroesContext _context;

        public IndexModel(HeroesWeb.Data.HeroesContext context)
        {
            _context = context;
        }

        public IList<SuperPoderes> SuperPoderes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            SuperPoderes = await _context.SuperPoderes.Include(s => s.Heroe).ToListAsync();
        }
    }
}