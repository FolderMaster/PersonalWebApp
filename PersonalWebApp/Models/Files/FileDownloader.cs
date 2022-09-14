using Microsoft.EntityFrameworkCore;

namespace PersonalWebApp.Models.Files
{
    public class FileDownloader
    {
        public static FileDbContext? FileDb { get; set; } = null;

        public static async Task<string?> DownloadPath(int id)
        {
            File? file = await FileDb.Files.FirstOrDefaultAsync(file => file.Id == id);
            if(file == null)
            {
                return null;
            }
            else
            {
                return file.Path;
            }
        }
    }
}