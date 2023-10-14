using Microsoft.EntityFrameworkCore;

namespace Web_API._Web_приложение__Музыкальный_портал_.Models
{
    public class Music_Portal_APIContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicStyle> MusicStyles { get; set; }
        public DbSet<Singer> Singers { get; set; }

        public Music_Portal_APIContext(DbContextOptions<Music_Portal_APIContext> options)
            : base(options)
        {
            
            if (Database.EnsureCreated()) 
            {
                Users.Add(new User { FirstName = "Admin", LastName = "Admin", Login = "Admin", Email = "admin@gmail.com", Password = "0B2FFE4FAE90F11F26F4223C2FDC95BB", Salt = "3CFD6F6D6ECA8B1F7037082D46788621", Level = 2 });
                SaveChanges();
            }
        }
    }
}
