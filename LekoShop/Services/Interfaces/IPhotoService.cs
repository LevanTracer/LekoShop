﻿using CloudinaryDotNet.Actions;

namespace LekoShop.Services.Interfaces
{
	public interface IPhotoService
	{
		Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
		Task<DeletionResult> DeletePhotoAsync(string Url);
			
	}
}
