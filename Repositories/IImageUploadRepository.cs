using polichousehold.Models;

namespace polichousehold.Repositories;

public interface IImageUploadRepository
{
    Task UploadImageToDb(ImageFile image);
    Task<IEnumerable<ImageFile>> GetImages();
}