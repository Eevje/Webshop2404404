using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Pages.Parts
{
    public class DetailsModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public DetailsModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public Part Part { get; set; }

        public IActionResult OnGet(int id)
        {
            Part = _context.Parts.FirstOrDefault(p => p.Id == id);

            if (Part == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}