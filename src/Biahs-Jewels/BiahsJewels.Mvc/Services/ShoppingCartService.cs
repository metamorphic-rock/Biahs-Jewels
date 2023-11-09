using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IShoppingCartService
{
    public Task<ShoppingCart> CreateShoppingCartForConsumerAsync(int consumerId);
    public Task<ShoppingCart> GetShoppingCartAsync(int consumerId);
    public Task AddItemToShoppingCartAsync(Product product, int consumerId);
    public Task<IEnumerable<ProductInCart>> GetProductInCartAsync(int shoppingCartId);
}
public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _appDbContext;
    private readonly IProductService _productService;
    public ShoppingCartService(AppDbContext appDbContext, IProductService productService)
    {
        _appDbContext = appDbContext;
        _productService = productService;
    }

    public async Task<ShoppingCart> CreateShoppingCartForConsumerAsync(int consumerId)
    {
        var item = _appDbContext.ShoppingCarts.FirstOrDefault(x => x.ConsumerId == consumerId);
        if (item == null)
        {
            var cart = new ShoppingCart()
            {
                ConsumerId = consumerId,
                ProductsInCart = new List<ProductInCart>()
            };
            _appDbContext.ShoppingCarts.Add(cart);
            await _appDbContext.SaveChangesAsync();
            return GetShoppingCartAsync(consumerId).Result;
        };

        return item;
    }

    public async Task<ShoppingCart> GetShoppingCartAsync(int consumerId)
    {
        return _appDbContext.ShoppingCarts.FirstOrDefault(x => x.ConsumerId == consumerId);
    }

    public async Task AddItemToShoppingCartAsync(Product product, int consumerId)
    {
        var item = await GetShoppingCartAsync(consumerId);
        if (item == null)
        {
            item = CreateShoppingCartForConsumerAsync(consumerId).Result;
        };
        item.ProductsInCart = new List<ProductInCart>();

        var productToAdd = new ProductInCart()
        {
            ProductId = product.Id,
            Product = product,
            ShoppingCartId = item.Id,
            Quantity = 1,
            TotalPrice = product.Price * 1,
        };

        item.ProductsInCart.Add(productToAdd);

        _appDbContext.ProductInCarts.Add(productToAdd);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductInCart>> GetProductInCartAsync(int shoppingCartId)
    {
        return _appDbContext.ProductInCarts.Where(x => x.ShoppingCartId == shoppingCartId);;
    }
}