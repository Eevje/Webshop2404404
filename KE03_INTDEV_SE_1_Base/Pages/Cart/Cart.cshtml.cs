using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using KE03_INTDEV_SE_1_Base.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace KE03_INTDEV_SE_1_Base.Pages.Cart
{
    public class CartModel : PageModel
    {
        public List<CartItem> Items { get; set; } = new();
        public decimal Total { get; set; }

        public void OnGet()
        {
            Items = HttpContext.Session.GetObject<List<CartItem>>("Cart") ?? new List<CartItem>();
            Total = Items.Sum(i => i.Price * i.Quantity);
        }
    }
}
