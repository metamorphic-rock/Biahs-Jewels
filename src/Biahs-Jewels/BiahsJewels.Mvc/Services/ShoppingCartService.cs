using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;
using BiahsJewels.Mvc.Models.ViewModel;

namespace BiahsJewels.Mvc.Services;

public interface IShoppingCartService
{
    public Task<ShoppingCart> CreateShoppingCartForConsumerAsync(int consumerId);
    public Task<ShoppingCart> GetShoppingCartAsync(int consumerId);
    public Task AddItemToShoppingCartAsync(Product product, int consumerId);
    public Task<IEnumerable<ProductInCart>> GetProductsInCartAsync(int shoppingCartId);
    public Task RemoveItemFromShoppingCartAsync(int productId, int consumerId);
    public Task<int> GetNumberOfProductsInCartAsync(int consumerId);
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

    // TODO: add validation to only add items that are not already in the cart
    public async Task AddItemToShoppingCartAsync(Product product, int consumerId)
    {
        var item = await GetShoppingCartAsync(consumerId);
        if (item == null)
        {
            item = CreateShoppingCartForConsumerAsync(consumerId).Result;
        };

        item.ProductsInCart = new List<ProductInCart>();

        var cartId = item.Id;
        var itemIsAlreadyInCart = IsProductAlreadyInShoppingCartAsync(cartId, product.Id);
        if (!itemIsAlreadyInCart.Result)
        {
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
        }

        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductInCart>> GetProductsInCartAsync(int shoppingCartId)
    {
        return _appDbContext.ProductInCarts.Where(x => x.ShoppingCartId == shoppingCartId);
    }

    public async Task RemoveItemFromShoppingCartAsync(int productId, int consumerId)
    {
        var item = await GetShoppingCartAsync(consumerId);
        if (item != null)
        {
            var productsInCart = await GetProductsInCartAsync(item.Id);
            item.ProductsInCart = productsInCart.ToList();
            var productToRemove = productsInCart?.FirstOrDefault(x => x.Product.Id == productId);

            if (productToRemove != null)
            {
                item?.ProductsInCart?.Remove(productToRemove);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }

    private async Task<bool> IsProductAlreadyInShoppingCartAsync(int shoppingCartId, int productId)
    {
        var shoppingCart = await GetProductsInCartAsync(shoppingCartId);
        if (shoppingCart == null)
        {
            throw new Exception("Shopping cart does not exist");
        }
        var item = shoppingCart.FirstOrDefault(x => x.ProductId == productId);
        return item != null;
    }

    public async Task<int> GetNumberOfProductsInCartAsync(int consumerId)
    {
        var item = await GetShoppingCartAsync(consumerId);
        if (item == null)
        {
            throw new Exception("Shopping cart does not exist");
        }
        var shoppingCartId = item.Id;
        var productsInCart = _appDbContext.ProductInCarts.Where(x => x.ShoppingCartId == shoppingCartId);
        return productsInCart.Count();
    }
}