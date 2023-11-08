using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IOrderService
{
    public Task CreateOrderAsync(int consumerId, Order order);
}
public class OrderService : IOrderService
{
    private readonly AppDbContext _appDbContext;

    public OrderService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateOrderAsync(int consumerId, Order order)
    {
        throw new NotImplementedException();
    }
}