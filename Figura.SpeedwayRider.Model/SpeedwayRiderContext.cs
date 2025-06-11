using Figura.SpeedwayRider.Model.DAO;
using Microsoft.EntityFrameworkCore;

namespace Figura.SpeedwayRider.Model;

public partial class SpeedwayRiderContext : DbContext
{
    private string? _connectionString;

    public SpeedwayRiderContext()
    {
    }

    public SpeedwayRiderContext(DbContextOptions<SpeedwayRiderContext> options)
        : base(options)
    {
    }

    public SpeedwayRiderContext(string? connectionString)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<Rider> Riders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Polish_100_CI_AI_KS_WS_SC_UTF8");

        modelBuilder.Entity<Rider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rider__3214EC0725737EC7");

            entity.ToTable("Rider");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Nationality).HasMaxLength(30);
            entity.Property(e => e.PictureUrl).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
