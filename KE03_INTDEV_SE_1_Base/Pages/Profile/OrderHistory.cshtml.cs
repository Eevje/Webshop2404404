using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace KE03_INTDEV_SE_1_Base.Pages.Profile
{
    public class OrderHistoryModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public OrderHistoryModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {
            Customers = _customerRepository.GetAllCustomers()
                .ToList(); // deze methode moet OrderItems + Product includen
        }
    }
}