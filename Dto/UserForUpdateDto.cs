namespace api.Dto
{
    public record UserForUpdateDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
    }
}