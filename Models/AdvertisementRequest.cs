using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class AdvertisementRequest
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public string? TextContent { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageContentType { get; set; } 

        public byte[]? VideoData { get; set; }
        public string? VideoContentType { get; set; }

        public DateTime RequestedAt { get; set; }
        public bool? IsApproved { get; set; }
    }

}