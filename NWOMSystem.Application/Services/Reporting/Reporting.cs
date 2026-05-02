    using NWOMSystem.Application.Services.OrderManagement;
    using NWOMSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

//These use cases are responsible for gathering and formatting data for the dashboard and document generation.
//They will use the repositories to get the data from the database and then format it for the presentation layer.
namespace NWOMSystem.Application.Services.Reporting
{


    public class Reporting
    {
        private readonly IOrderRepository _orderRepository;

        // Constructor to inject the repository dependency   
        public Reporting(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersForDashboardAsync()
        {
            // Here we can add any additional logic to filter or format the orders for the dashboard
            return await _orderRepository.GetAllOrdersAsync();
            
            //???? will be a good practice to get al the orders and then filter using linq or should I add a method in the repository to get only the orders that are needed for the dashboard?


        }

        // Additional methods for generating reports and documents can be added here
    }

}