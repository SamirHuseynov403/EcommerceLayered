using Microsoft.AspNetCore.Http;

namespace Ecommerce.BLL.DataFile
{
    public static class FileExtensions
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static bool IsAllowedSize(this IFormFile file, int mb)
        {
            return file.Length <= mb * 1024 * 1024;
        }

        public static async Task<string> GenerateFile(this IFormFile file, string folderName, string extension = null!)
        {
            if (string.IsNullOrEmpty(extension))
                extension = Path.GetExtension(file.FileName).ToLower();

            // wwwroot/{folderName} qovluğunu tapırıq
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);

            if (!Directory.Exists(wwwRootPath))
                Directory.CreateDirectory(wwwRootPath);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var fullPath = Path.Combine(wwwRootPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }


    }
}
