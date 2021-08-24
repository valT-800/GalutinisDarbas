using Microsoft.EntityFrameworkCore;

namespace Games.Model
{
    public partial class GamesContext : DbContext
    {
        public GamesContext()
        {
        }

        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Seen> Seen { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\;Database=Games;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Genre).IsUnicode(false);

                entity.Property(e => e.Length).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Seen>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Seen)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Seen__Game");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.Date).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Wishlist__Game");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
