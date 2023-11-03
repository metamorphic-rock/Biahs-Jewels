using BiahsJewels.Mvc.Data;

namespace BiahsJewels.Mvc.Services;

public interface IInventoryService
{
    public Task<int> GetProductQuantity(int productId);
    public Task AddProductQuantity(int productId, int quantity);
    public Task ReduceProductQuantity(int productId, int quantity);
}
public class InventoryService : IInventoryService
{
    private readonly AppDbContext _appDbContext;

    public InventoryService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> GetProductQuantity(int productId)
    {
        throw new NotImplementedException();
    }

    public async Task AddProductQuantity(int productId, int quantity)
    {
        var item = await _appDbContext.Products.FindAsync(productId);

        if (item == null)
        {
            throw new Exception("Products not found");
        }

        if (item.QuantityAvailable == null)
        {
            item.QuantityAvailable = quantity;
        }
        else
        {
            item.QuantityAvailable = item.QuantityAvailable + quantity;
        }

        await _appDbContext.SaveChangesAsync();
    }

    public Task ReduceProductQuantity(int productId, int quantity)
    {
        throw new NotImplementedException();
    }
}