using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICustomerRepository _customerRepository;

        public IList<Customer> Customers { get; set; } = new List<Customer>();

        public IndexModel(ILogger<IndexModel> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public void OnGet()
        {
            Customers = _customerRepository.GetAllCustomers().ToList();

            _logger.LogInformation($"Loaded {Customers.Count} customers with orders.");
        }
    }
}
