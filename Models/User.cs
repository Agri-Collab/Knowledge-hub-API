namespace api.Models{
    public class User {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Surname { get; set;}
        public int ContactNo { get; set;}
        public DateTimeOffset CreatedAt { get; set; }
        
    }
}