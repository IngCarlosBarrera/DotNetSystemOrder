using Microsoft.EntityFrameworkCore;
using NWOMSystem.Application.Services.OrderManagement;
using NWOMSystem.Domain.Entities;
using NWOMSystem.Infrastructure.Data;

namespace NWOMSystem.Infrastructure;

// Implementing Order Repository using EF Core
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddOrderAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);  // Find the order by ID
        if (order != null)
        {
            _context.Orders.Remove(order);  //Remove the order from the context
            await _context.SaveChangesAsync(); // Save changes to the database
        }
    }
    

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int orderId)
    {
        return await _context.Orders.FindAsync(orderId);                
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _context.Orders.Update(order); // Update the order in the context
        await _context.SaveChangesAsync(); // Save changes to the database
    }


}
