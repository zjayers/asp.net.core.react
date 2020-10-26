using Core.PhotoUpload;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces
{
    public interface IPhotoAccessor
    {
        PhotoUploadResult AddPhoto(IFormFile file);
        string DeletePhoto(string photoId);
    }
}
