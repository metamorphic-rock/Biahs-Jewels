using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IProductService
{
    public List<Product> GetProducts();
    public Product GetProductById(int id);
    public Product GetProductByName(string name);
    public void SaveProduct(Product product);
    public void EditProduct(Product product);
    public void DeleteProduct(int id);
}
public class ProductServices : IProductService
{
    private readonly AppDbContext _appDbContext;

    public ProductServices (AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public List<Product> GetProducts()
    {
        return _appDbContext.ProductItem.ToList();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Product GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public void SaveProduct(Product product)
    {
        _appDbContext.ProductItem.Add(product);
        _appDbContext.SaveChangesAsync();
    }
    public void EditProduct(Product product)
    {
        throw new NotImplementedException();
    }
    public void DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}
