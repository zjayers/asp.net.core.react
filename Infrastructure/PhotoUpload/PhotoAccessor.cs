using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Interfaces;
using Core.PhotoUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.PhotoUpload
{
    public class PhotoAccessor : IPhotoAccessor
    {
        private readonly Cloudinary _cloudinary;

        /// <summary>
        /// Photo Accessor
        /// </summary>
        /// <param name="config">Get user secrets - they will be strongly typed</param>
        public PhotoAccessor(IOptions<CloudinarySettings> config)
        {
            var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public PhotoUploadResult AddPhoto(IFormFile file)
        {
            // Create result handler
            var uploadResult = new ImageUploadResult();


            // If the file is not empty, open a read stream, upload the file
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadResult = _cloudinary.Upload(uploadParams);
            }

            // Check for errors
            if (uploadResult.Error != null)
                throw new Exception(uploadResult.Error.Message);

            // Retrieve the uploaded file information and return it
            return new PhotoUploadResult()
            {
                PublidId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.AbsoluteUri
            };
        }

        public string DeletePhoto(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var result = _cloudinary.Destroy(deletionParams);
            return result.Result == "ok" ? result.Result : null;
        }
    }
}
