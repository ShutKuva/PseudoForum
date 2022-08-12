using Core;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ForumDbContext : DbContext
    {
        public DbSet<User> Authors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {

        }

        public ForumDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(post => post.Topic)
                .WithMany(topic => topic.Posts)
                .HasForeignKey(post => post.TopicId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=ZHEKA\\SQLEXPRESS;Database=ForumDb;Trusted_Connection=True;");
        }
    }
}
