using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IShoppingCartService
{
    public Task CreateShoppingCartForConsumerAsync(int consumerId);
    public Task<ShoppingCart> GetShoppingCartAsync(int consumerId);
    public Task AddItemToShoppingCartAsync(Product product, int consumerId);
}
public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _appDbContext;
    public ShoppingCartService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateShoppingCartForConsumerAsync(int consumerId)
    {
        var item = _appDbContext.ShoppingCarts.FirstOrDefault(x => x.ConsumerId == consumerId);
        if(item == null)
        {
            var cart = new ShoppingCart()
            {
                ConsumerId = consumerId,
                ProductsInCart = new List<Product>()
            };
            _appDbContext.ShoppingCarts.Add(cart);
            await _appDbContext.SaveChangesAsync();
        };

    }

    public async Task<ShoppingCart> GetShoppingCartAsync(int consumerId)
    {
        return _appDbContext.ShoppingCarts.FirstOrDefault(x => x.ConsumerId == consumerId);
    }

    public async Task AddItemToShoppingCartAsync(Product product, int consumerId)
    {
        var item = await _appDbContext.ShoppingCarts.FindAsync(consumerId);
        if( item == null)
        {
            CreateShoppingCartForConsumerAsync(consumerId);
        }

        item = GetShoppingCartAsync(consumerId).Result;
        item.ProductsInCart = new List<Product>();

        var productToAdd = new Product()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImagePath = product.ImagePath,
            Price = product.Price,
        };

        item.ProductsInCart.Add(productToAdd);
    }
}