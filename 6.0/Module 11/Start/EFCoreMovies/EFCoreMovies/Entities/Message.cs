namespace EFCoreMovies.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int SenderId { get; set; }
        public Person Sender { get; set; }
        public int ReceiverId { get; set; }
        public Person Receiver { get; set; }
    }
}
