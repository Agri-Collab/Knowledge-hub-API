using api.Models;
using api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace api.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _repository;

        public AdvertisementService(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public async Task<AdvertisementRequest> CreateRequestAsync(AdvertisementRequestForCreateDto dto, string userId)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var request = new AdvertisementRequest
            {
                UserId = string.IsNullOrEmpty(userId) ? (int?)null : int.Parse(userId),
                TextContent = dto.TextContent,
                RequestedAt = DateTime.UtcNow
            };

       
            if (dto.ImageFile != null && dto.ImageFile.Length > 0)
            {
                request.ImageData = await ConvertToBytes(dto.ImageFile);
                request.ImageContentType = dto.ImageFile.ContentType;
            }

            if (dto.VideoFile != null && dto.VideoFile.Length > 0)
            {
                request.VideoData = await ConvertToBytes(dto.VideoFile);
                request.VideoContentType = dto.VideoFile.ContentType;
            }

            return await _repository.AddAsync(request);
        }
        public async Task<IEnumerable<AdvertisementRequest>> GetPendingRequestsAsync()
        {
            return await _repository.GetPendingAsync();
        }

        public async Task<AdvertisementRequest?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task ReviewRequestAsync(int id, bool approve)
        {
            var ad = await _repository.GetByIdAsync(id);
            if (ad == null)
                throw new Exception("Advertisement not found");

            ad.IsApproved = approve;
            await _repository.UpdateAsync(ad);
        }

        private async Task<byte[]> ConvertToBytes(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Array.Empty<byte>();

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
