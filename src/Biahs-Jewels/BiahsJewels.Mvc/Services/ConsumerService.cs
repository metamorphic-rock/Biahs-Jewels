using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;
using System.Collections;

namespace BiahsJewels.Mvc.Services;

public interface IConsumerService
{
    public Task CreateConsumerAsync(Consumer consumer);
    public Task UpdateConsumerDetailsAsync(int consumerId,Consumer consumer);
    public Task<IEnumerable<Consumer>> GetAllConsumerAsync();
}
public class ConsumerService : IConsumerService
{
    private readonly AppDbContext _appDbContext;

    public ConsumerService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateConsumerAsync(Consumer consumer)
    {
        if (consumer != null)
        {
            _appDbContext.Consumers.Add(consumer);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Consumer>> GetAllConsumerAsync()
    {
        var consumers = _appDbContext.Consumers.ToList();
        return consumers;
    }

    public async Task UpdateConsumerDetailsAsync(int consumerId, Consumer consumer)
    {
        throw new NotImplementedException();
    }
}