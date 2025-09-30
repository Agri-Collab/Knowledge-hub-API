using System;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementsController : ControllerBase
    {
        private readonly IServiceManager _services;

        public AdvertisementsController(IServiceManager services)
        {
            _services = services;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SubmitAd([FromForm] AdvertisementRequestForCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Advertisement data is missing.");

            try
            {
                var result = await _services.AdvertisementService.CreateRequestAsync(dto, userId: "");

                return Ok(new
                {
                    result.Id,
                    result.UserId,
                    UserName = "Anonymous",
                    result.TextContent,
                    HasImage = result.ImageData != null,
                    HasVideo = result.VideoData != null,
                    result.RequestedAt
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in SubmitAd: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("pending")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPendingAds()
        {
            try
            {
                var ads = await _services.AdvertisementService.GetPendingRequestsAsync();

                var result = ads.Select(a => new
                {
                    a.Id,
                    a.UserId,
                    UserName = "Anonymous",
                    a.TextContent,
                    HasImage = a.ImageData != null,
                    HasVideo = a.VideoData != null,
                    a.RequestedAt
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in GetPendingAds: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{id}/review")]
        [AllowAnonymous]
        public async Task<IActionResult> ReviewAd(int id, [FromBody] AdvertisementReviewDto dto)
        {
            if (dto == null)
                return BadRequest("Review data is missing.");

            try
            {
                await _services.AdvertisementService.ReviewRequestAsync(id, dto.Approve);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in ReviewAd: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}/media")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAdvertisementMedia(int id)
        {
            var ad = await _services.AdvertisementService.GetByIdAsync(id);
            if (ad == null)
                return NotFound(new { message = "Advertisement not found" });

            if (ad.ImageData != null)
                return File(ad.ImageData, ad.ImageContentType ?? "image/jpeg");

            if (ad.VideoData != null)
                return File(ad.VideoData, ad.VideoContentType ?? "video/mp4");

            return NotFound(new { message = "No media available for this advertisement" });
        }

    }
}
