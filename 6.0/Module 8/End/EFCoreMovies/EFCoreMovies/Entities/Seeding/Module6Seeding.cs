using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies.Entities.Seeding
{
    public static class Module6Seeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var felipe = new Person() { Id = 1, Name = "Felipe" };
            var claudia = new Person() { Id = 2, Name = "Claudia" };

            var message1 = new Message { Id = 1, Content = "Hello, Claudia!", 
                SenderId = felipe.Id, ReceiverId = claudia.Id };
            var message2 = new Message
            {
                Id = 2,
                Content = "Hello, Felipe, how are you?",
                SenderId = claudia.Id,
                ReceiverId = felipe.Id
            };
            var message3 = new Message
            {
                Id =3,
                Content = "All good, and you?",
                SenderId = felipe.Id,
                ReceiverId = claudia.Id
            };
            var message4 = new Message
            {
                Id = 4,
                Content = "Very good :)",
                SenderId = claudia.Id,
                ReceiverId = felipe.Id
            };

            modelBuilder.Entity<Person>().HasData(felipe, claudia);
            modelBuilder.Entity<Message>().HasData(message1, message2, message3, message4);
        }
    }
}
