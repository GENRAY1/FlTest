using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task2.Model;

namespace Task2.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagToUser>()
                .HasKey(t => new { t.EntityId });

            modelBuilder.Entity<TagToUser>()
               .HasOne(t => t.User)
               .WithMany(u => u!.TagToUsers)
               .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<TagToUser>()
               .HasOne(t => t.Tag)
               .WithMany(t => t!.TagToUsers)
               .HasForeignKey(t => t.TagId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TagToUser> TagsToUsers { get; set; }
        
        
    }
}
