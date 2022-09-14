using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Files
{
    public class FileUploader
    {
        private const string _filePath = "/Files/";

        public static async Task<File?> Upload(IFormFile uploadedFile, IWebHostEnvironment webHostEnvironment, FileDbContext dbContext)
        {
            if(uploadedFile != null)
            {
                using (FileStream stream = new FileStream(webHostEnvironment.WebRootPath + _filePath + uploadedFile.Name, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(stream);
                }
                File createdFile = new File(uploadedFile.Name, _filePath + uploadedFile.Name, DateTime.Now);
                dbContext.Files.Add(createdFile);
                await dbContext.SaveChangesAsync();
                return await dbContext.Files.FirstOrDefaultAsync(file => file.Name == createdFile.Name);
            }
            else
            {
                return null;
            }
        }
    }
}