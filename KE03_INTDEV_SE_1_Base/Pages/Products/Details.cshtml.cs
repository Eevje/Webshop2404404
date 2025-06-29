using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Helpers;

namespace KE03_INTDEV_SE_1_Base.Pages.Products
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

        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (Product == null)
                return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == Product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += Quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = Product.Id,
                    ProductName = Product.Name,
                    ImageUrl = Product.ImageUrl,
                    Price = Product.Price,
                    Quantity = Quantity
                });
            }

            HttpContext.Session.SetObject("Cart", cart);

            TempData["Message"] = $"{Quantity}x {Product.Name} toegevoegd aan winkelmandje.";
            return RedirectToPage("Index");
        }
    }
}