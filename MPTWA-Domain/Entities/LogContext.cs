using Microsoft.EntityFrameworkCore;

namespace MPTWA_Domain.Entities;

public class LogContext :DbContext
{
    private readonly string? _connectString;
    public DbSet<RequestLogEntity> RequestLogs { get; set; }
    public DbSet<ResultsLog> ResultsLogs { get; set; }
    
    public LogContext(string connectString) 
    {
        _connectString = connectString;
    }
    public LogContext(DbContextOptions options) :
        base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!string.IsNullOrWhiteSpace(_connectString))
        {
            optionsBuilder.UseNpgsql(_connectString,
                assembly => assembly.MigrationsAssembly("MPTWA-Infrastructure"));
        }
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(property => property.Name == nameof(BaseEntity.CreateTime))
            .Select(property => modelBuilder.Entity(property.DeclaringEntityType.ClrType)
                .Property(nameof(BaseEntity.CreateTime))).ToList()
            .ForEach(builder => builder.HasDefaultValueSql("now()"));
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(property => property.Name == nameof(BaseEntity.Id))
            .Select(property => modelBuilder.Entity(property.DeclaringEntityType.ClrType)
                .Property(nameof(BaseEntity.Id))).ToList()
            .ForEach(builder => builder.HasDefaultValueSql("uuid_generate_v4()"));
    }
}