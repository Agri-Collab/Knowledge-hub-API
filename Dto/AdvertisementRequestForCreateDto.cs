public class AdvertisementRequestForCreateDto
{
    public string? TextContent { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile? VideoFile { get; set; }
}
