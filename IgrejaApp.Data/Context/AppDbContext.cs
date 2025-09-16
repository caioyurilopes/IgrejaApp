namespace IgrejaApp.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Batismo> Batismos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).ValueGeneratedOnAdd();

            entity.HasOne(u => u.Conjuge)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.ConjugeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Batismo>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).ValueGeneratedOnAdd();

            entity.HasOne(b => b.Pastor)
                .WithMany()
                .HasForeignKey(b => b.PastorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}