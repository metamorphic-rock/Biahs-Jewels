using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IProductService
{
    public Task<IEnumerable<Product>> GetProducts();
    public Task<IEnumerable<ProductCategory>> GetProductCategories();
    public Task<Product> GetProductById(int id);
    public Task<Product> GetProductByName(string name);
    public Task CreateProduct(Product product);
    public Task EditProduct(Product product);
    public Task DeleteProduct(int id);
}
public class ProductServices : IProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductServices (AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var products = _appDbContext.Products.ToList();
        return products;
    }

    public async Task<IEnumerable<ProductCategory>> GetProductCategories()
    {
        return _appDbContext.ProductCategories.ToList();
    }
    public async Task<Product> GetProductById(int id)
    {
        return await _appDbContext.Products.FindAsync(id);
    }

    public async Task<Product> GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task CreateProduct(Product product)
    {
        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task EditProduct(Product product)
    {
        var item = _appDbContext.Products.FirstOrDefault(x => x.Id == product.Id);
        if (item == null)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
        }

        item.Name = product.Name;
        item.ProductImage = product.ProductImage;
        item.Description = product.Description;
        item.Price = product.Price;
        item.Rating = product.Rating;
        item.ImagePath = product.ImagePath;

        _appDbContext.Products.Update(item);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var item = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            throw new Exception("product not found");
        }

        _appDbContext.Products.Remove(item);
        await _appDbContext.SaveChangesAsync();
    }
}
