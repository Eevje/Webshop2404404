using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Helpers;

namespace KE03_INTDEV_SE_1_Base.Pages.Parts
{
    public class DetailsModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public DetailsModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Quantity { get; set; } = 1;

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

        public IActionResult OnPost(int id)
        {
            Part = _context.Parts.FirstOrDefault(p => p.Id == id);

            if (Part == null)
                return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == Part.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += Quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = Part.Id,
                    ProductName = Part.Name,
                    ImageUrl = Part.ImageUrl,
                    Price = Part.Price,
                    Quantity = Quantity
                });
            }

            HttpContext.Session.SetObject("Cart", cart);

            TempData["Message"] = $"{Quantity}x {Part.Name} toegevoegd aan winkelmandje.";
            return Page();

        }
    }
}
