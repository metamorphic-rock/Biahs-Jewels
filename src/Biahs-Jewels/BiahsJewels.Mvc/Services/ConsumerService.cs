using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;
using System.Collections;

namespace BiahsJewels.Mvc.Services;

public interface IConsumerService
{
    public Task CreateConsumerAsync(Consumer consumer);
    public Task UpdateConsumerProfileAsync(int consumerId,Consumer consumer);
    public Task<IEnumerable<Consumer>> GetAllConsumerAsync();
    public Task<Consumer> GetConsumerByAccountIdAsync(string accountId);
    public Task<Consumer> GetConsumerByConsumerIdAsync(int consumerId);
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
    public async Task<Consumer> GetConsumerByAccountIdAsync(string accountId)
    {
        var consumer = _appDbContext.Consumers.FirstOrDefault(consumer => consumer.AccountId == accountId);
        return consumer;
    }

    public async Task<Consumer> GetConsumerByConsumerIdAsync(int consumerId)
    {
        var consumer = await _appDbContext.Consumers.FindAsync(consumerId);
        return consumer;
    }

    public async Task UpdateConsumerProfileAsync(int consumerId, Consumer consumer)
    {
        throw new NotImplementedException();
    }
}