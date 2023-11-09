using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BiahsJewels.Mvc.Services;

public interface IConsumerService
{
    public Task CreateConsumerAsync(Consumer consumer);
    public Task UpdateConsumerProfileAsync(int consumerId, Profile consumerProfile);
    public Task<IEnumerable<Consumer>> GetAllConsumerAsync();
    public Task<Consumer> GetConsumerByAccountIdAsync(string accountId);
    public Task<Address> GetConsumerAddressByConsumerIdAsync(int consumerId);
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

    public async Task<Address> GetConsumerAddressByConsumerIdAsync(int consumerId)
    {
        return await _appDbContext.Addresses.FirstOrDefaultAsync(x => x.ConsumerId == consumerId);
    }

    public async Task UpdateConsumerProfileAsync(int consumerId, Profile consumerProfile)
    {
        var item = await _appDbContext.Consumers.FindAsync(consumerId);
        if(item == null)
        {
            throw new Exception("consumer not found");
        }
        item.Email = consumerProfile.Email;
        item.BirthDay = consumerProfile.BirthDay;

        if (item.Address == null)
        {
            item.Address = new Address()
            {
                ConsumerId = consumerId,
                PrimaryAddress = consumerProfile.Address.PrimaryAddress,
                SecondaryAddress = consumerProfile.Address.SecondaryAddress
            };

            await _appDbContext.Addresses.AddAsync(item.Address);
            await _appDbContext.SaveChangesAsync();
        }
        else 
        {
            item.Address.PrimaryAddress = consumerProfile.Address.PrimaryAddress;
            item.Address.SecondaryAddress = consumerProfile.Address.SecondaryAddress;
            _appDbContext.Addresses.Update(item.Address);
            await _appDbContext.SaveChangesAsync();
        }

        item.PrimaryContactNumber = consumerProfile.PrimaryContactNumber;
        item.SecondaryContactNumber = consumerProfile.SecondaryContactNumber;

        _appDbContext.Consumers.Update(item);
        await _appDbContext.SaveChangesAsync();
        
    }
}