using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using LekoShop.Helper;
using LekoShop.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace LekoShop.Services
{
	public class PhotoService : IPhotoService
	{
		private readonly Cloudinary _cloudinary;

		public PhotoService(IOptions<CloudinarySettings> config)
		{
			var acc = new Account(
				config.Value.CloudName,
				config.Value.ApiKey,
				config.Value.ApiSecret
				
				);
			_cloudinary=new Cloudinary(acc);


		}
		public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
		{
			var imageUploadResult = new ImageUploadResult();
			using var stream=file.OpenReadStream();
			if (file.Length > 0)
			{
				var uploadParams = new ImageUploadParams
				{
					File = new FileDescription(file.FileName, stream),
					Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
				};
				imageUploadResult= await _cloudinary.UploadAsync(uploadParams);				
			}
			
			return imageUploadResult;
			
		}

		public async Task<DeletionResult> DeletePhotoAsync(string Url)
		{
            var publicId = Url.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);			
            return await _cloudinary.DestroyAsync(deleteParams);
        }
	}
}
