using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XamarinApp.MobileAppService.Models
{
    public partial class ChatDbContext : DbContext
    {
        public ChatDbContext()
        {
        }

        public ChatDbContext(DbContextOptions<ChatDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chats> Chats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=ChatDb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Chats>(entity =>
            {
                entity.HasKey(e => e.ChatId);

                entity.HasIndex(e => e.ChatId)
                    .IsUnique();

                entity.HasIndex(e => e.GroupId)
                    .IsUnique();

                entity.Property(e => e.ChatId).ValueGeneratedNever();
            });
        }
    }
}
