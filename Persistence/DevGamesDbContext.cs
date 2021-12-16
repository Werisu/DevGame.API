using System.Collections.Generic;
using DevGames.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGames.API.Persistence
{
    public class DevGamesDbContext : DbContext
    {
        public DevGamesDbContext(DbContextOptions<DevGamesDbContext> options) : base(options)
        {

        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().HasKey(b => b.Id);

            modelBuilder.Entity<Board>()
            .HasMany(b => b.Posts) // um board tem muitos posts
            .WithOne() // um post tem um board
            .HasForeignKey(p => p.BoardId); // a chave estrangéria é o boardId

            modelBuilder.Entity<Post>().HasKey(p => p.Id);

            modelBuilder.Entity<Post>()
            .HasMany(c => c.Comments)
            .WithOne()
            .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Comment>().HasKey(c => c.Id);
        }
        
        
    }
}