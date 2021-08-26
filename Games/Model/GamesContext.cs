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
        public virtual DbSet<Played> Played { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H1FIN35\\SQLEXPRESS;Database=Games;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Genre).IsUnicode(false);

                entity.Property(e => e.Levels).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Played>(entity =>
            {
                entity.Property(e => e.Comment).IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Played)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Played__Game");
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
