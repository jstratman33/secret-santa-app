using Microsoft.EntityFrameworkCore;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.EfCore
{
    public class SecretSantaContext : DbContext
    {
        public SecretSantaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GroupMemberLink> GroupMemberLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMemberLink>().HasKey(e => new {e.GroupId, e.MemberId});
            modelBuilder.Entity<GroupMemberLink>().HasOne(e => e.Group).WithMany(e => e.MemberLinks).HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<GroupMemberLink>().HasOne(e => e.Member).WithMany(e => e.GroupLinks).HasForeignKey(e => e.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Group>().HasKey(e => e.Id);
            modelBuilder.Entity<Group>().HasOne(e => e.Admin).WithMany(e => e.AdminOf).HasForeignKey(e => e.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Invite>().HasKey(e => e.Id);
            modelBuilder.Entity<Invite>().HasOne(e => e.Group).WithMany(e => e.Invites).HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<List>().HasKey(e => e.Id);
            modelBuilder.Entity<List>().HasOne(e => e.Owner).WithMany(e => e.Lists).HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<List>().HasOne(e => e.Santa).WithMany(e => e.SantaLists).HasForeignKey(e => e.SantaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<List>().HasOne(e => e.Group).WithMany(e => e.Lists).HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ListItem>().HasKey(e => e.Id);
            modelBuilder.Entity<ListItem>().HasOne(e => e.List).WithMany(e => e.Items).HasForeignKey(e => e.ListId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasKey(e => e.Id);
        }
    }
}