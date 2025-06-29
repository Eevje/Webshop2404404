using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Pages.Parts
{
    public class IndexModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        //deze lijst wordt naar de Razor Page gestuurd
        public List<Part> Parts { get; set; } = new();

        public IndexModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        //OnGet wordt uitgevoerd wanneer de pagina wordt geladen
        public void OnGet()
        {
            //producten ophalen uit database
            Parts = _context.Parts.ToList();
        }
    }
}
