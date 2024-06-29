using CloudinaryDotNet.Actions;

namespace WebAPIForArtists.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}
