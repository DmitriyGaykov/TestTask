using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Order> GetOrder()
    {
        return this._dbContext.Orders
            .OrderByDescending(order => order.Price * order.Quantity)
            .FirstOrDefaultAsync();
    }

    public Task<List<Order>> GetOrders()
    {
        return this._dbContext.Orders
            .Where(order => order.Quantity > 10)
            .ToListAsync();
    }
}