namespace api.Dtos
{
    public class PrivateChatDto
    {
        public int Id { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }
        public string User1Name { get; set; }
        public string User2Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
