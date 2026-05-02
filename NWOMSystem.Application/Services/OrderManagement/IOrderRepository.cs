using NWOMSystem.Domain.Entities;
//Define the IRepository interface for the Order entity
//This interface will be implemented by the Infrastructure layer to provide data access functionality for the Order entity.
namespace NWOMSystem.Application.Services.OrderManagement
{
public interface IOrderRepository
{
    Task<Order> GetOrderByIdAsync(int orderId); // Method to get an order by its ID
    Task<IEnumerable<Order>> GetAllOrdersAsync(); // Method to get all orders
    Task AddOrderAsync(Order order); // Method to add a new order
    Task UpdateOrderAsync(Order order); // Method to update an existing order
    Task DeleteOrderAsync(int orderId); // Method to delete an order
}
}