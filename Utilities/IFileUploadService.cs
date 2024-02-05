using Microsoft.AspNetCore.Components.Forms;

namespace polichousehold.Utilities;

public interface IFileUploadService
{
    Task<(int, string)> UploadFileAsync(IBrowserFile file, int maxFileSize, string[] allowedExtensions);
}
