using Microsoft.EntityFrameworkCore;

namespace WebAPI_TP3.Models.EntityFramework;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notation> Notations { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLoggerFactory(MyLoggerFactory)
            .EnableSensitiveDataLogging().UseNpgsql("Server=localhost;port=5432;Database=postgres; uid=postgres; password=postgres;SearchPath=public;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.Entity<Notation>(entity =>
        {
            entity.HasKey(e => new { e.UtilisateurId, e.SerieId }).HasName("pk_notation");

            entity.HasOne(d => d.UtilisateurNotant).WithMany(p => p.NotesUtilisateur)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_not_utl");

            entity.HasOne(d => d.SerieNotee).WithMany(p => p.NotesSerie)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_not_ser");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e. UtilisateurId).HasName("pk_utilisateur");
            entity.Property(e => e.DateCreation).HasDefaultValueSql("Now()");
            entity.Property(e => e.Pays).HasDefaultValue("France");

        });

        modelBuilder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.SerieId).HasName("pk_serie");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
