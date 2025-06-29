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

        public IList<Customer> Customers { get; set; }

        public OrderHistoryModel(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {
            // Zorg dat dit klanten met orders ophaalt (incl. orders via Include)
            Customers = _customerRepository.GetAllCustomers().ToList();
        }
    }
}
