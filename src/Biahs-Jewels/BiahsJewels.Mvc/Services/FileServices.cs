using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models;
using System.Security.AccessControl;

namespace BiahsJewels.Mvc.Services;

public interface IFileService
{
    public string CreateFileName(string fileName);
    public Task<string> UploadFile(Product product);
    public Task<string> UpdateFile(string fileName, Product product);
    public Task<string> UploadProfilePictureAsync(Profile consumer);
    public Task<string> UpdateProfilePictureAsync(string fileName, Profile consumer);
    public Task DeleteFile(string fileName);
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
        if (product.ProductImage != null)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + $"{CreateFileName(product.Name)}.png";
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                product.ProductImage.CopyTo(fileStream);
            }
        }
        return fileName;
    }

    public async Task<string> UpdateFile(string fileName, Product product)
    {
        var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var fileToUpdatePath = Path.Combine(imageFolderPath, fileName);
        var updatedFileName = fileName;
        if (File.Exists(fileToUpdatePath))
        {
            try
            {
                if (product.ProductImage != null)
                {
                    File.Delete(fileToUpdatePath);
                    updatedFileName = Guid.NewGuid().ToString() + "_" + $"{CreateFileName(product.Name)}.png";
                    var updatedFilePath = Path.Combine(imageFolderPath, updatedFileName);
                    using (var fileStream = new FileStream(updatedFilePath, FileMode.Create))
                    {
                        product.ProductImage.CopyTo(fileStream);
                    }
                }
            }
            catch
            {
                throw new Exception("File cannot be found");
            }
        }
        return updatedFileName;
    }

    public async Task<string> UploadProfilePictureAsync(Profile consumer)
    {
        var fileName = string.Empty;
        if(consumer.ProfilePicture != null)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "profilePictures");
            var filePath = Path.Combine(uploadsFolder, fileName);
            fileName = Guid.NewGuid().ToString() + "_" + $"{CreateFileName($"{consumer.FirstName}{consumer.LastName}")}.png";
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                consumer.ProfilePicture.CopyTo(fileStream);
            }
        }
        return fileName;
    }

    public async Task<string> UpdateProfilePictureAsync(string fileName, Profile consumer)
    {
        var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "profilePictures");
        var fileToUpdatePath = Path.Combine(imageFolderPath, fileName);
        var updatedFileName = fileName;
        if (File.Exists(fileToUpdatePath))
        {
            try 
            {
                if(consumer.ProfilePicture != null)
                {
                    File.Delete(fileToUpdatePath);
                    fileName = Guid.NewGuid().ToString() + "_" + $"{CreateFileName($"{consumer.FirstName}{consumer.LastName}")}.png";
                    var updatedFilePath = Path.Combine(imageFolderPath, updatedFileName);
                    using (var fileStream = new FileStream(updatedFilePath, FileMode.Create))
                    {
                        consumer.ProfilePicture.CopyTo(fileStream);
                    }
                }
            }
            catch
            {
                throw new Exception("File cannot be found");
            }
        }
        return fileName;
    }

    public async Task DeleteFile(string fileName)
    {
        var imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
        var fileToDeletePath = Path.Combine(imageFolderPath, fileName);
        if (File.Exists(fileToDeletePath))
        {
            try
            {
                File.Delete(fileToDeletePath);
            }
            catch 
            {
                throw new Exception("File cannot be found"); 
            }
        }
    }
}