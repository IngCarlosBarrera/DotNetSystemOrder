//These use case handle the primary CRUD operations required for the Order 

namespace NWOMSystem.Application.Services.OrderManagement
{
    using NWOMSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;


public class OrderManagement
{
    //including the IOrderRepository as a dependency to perform data access operations related to orders. This allows the use case to interact with the database through the repository, while keeping the business logic separate from the data access logic.
    private readonly IOrderRepository _orderRepository;

    // Constructor to inject the repository dependency
    public OrderManagement(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Order> GetOrderByIdAsync(int orderId) 
    {
        return await _orderRepository.GetOrderByIdAsync(orderId);
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync() 
    {
        return await _orderRepository.GetAllOrdersAsync();
    }

    public async Task AddOrderAsync(Order order)
    {
        await _orderRepository.AddOrderAsync(order);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await _orderRepository.UpdateOrderAsync(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        await _orderRepository.DeleteOrderAsync(orderId);
    }


}
}