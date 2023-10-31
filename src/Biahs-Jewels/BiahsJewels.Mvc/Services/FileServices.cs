using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Services;

public interface IFileService
{
    public Task<string> UploadFile(Product product);
    public Task DeleteFile(string productName);
    public string CreateFileName(string fileName);
}
public class FileService : IFileService
{
    private readonly AppDbContext _appDbContext;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
    {
        _appDbContext = appDbContext;
        _webHostEnvironment = webHostEnvironment;
    }

    public string CreateFileName(string str)
    {
        var fileName = string.Empty;
        if (string.IsNullOrEmpty(str))
        {
            throw new Exception("File name should not be empty");
        }
        fileName = str.Replace(" ", "");
        return fileName;
    }

    public async Task<string> UploadFile(Product product)
    {
        var fileName = string.Empty;
        if (product.ImageFile != null)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + $"{CreateFileName(product.Name)}.png";
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(fileStream);
            }
        }
        return fileName;
    }

    public async Task DeleteFile(string productName)
    {
        var wwwrootImageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var files = Directory.GetFiles(wwwrootImageFolder);
        productName = CreateFileName(productName);
        var fileToDelete = files.FirstOrDefault(x => x.Contains(productName));
        if (File.Exists(fileToDelete))
        {
            try
            {
                File.Delete(fileToDelete);
            }
            catch 
            {
                throw new Exception("File cannot be found"); 
            }
        }
    }
}