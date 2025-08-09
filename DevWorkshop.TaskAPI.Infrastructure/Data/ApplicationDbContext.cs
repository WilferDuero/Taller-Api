using DevWorkshop.TaskAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevWorkshop.TaskAPI.Infrastructure.Data;

/// <summary>
/// Contexto de base de datos principal de la aplicación
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Conjunto de entidades de usuarios
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Conjunto de entidades de tareas
    /// </summary>
    public DbSet<TaskItem> Tasks { get; set; }

    /// <summary>
    /// Conjunto de entidades de roles
    /// </summary>
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de la entidad User
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasIndex(e => e.Email)
                .IsUnique();

            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime2(7)");

            entity.Property(e => e.LastTokenIssueAt)
                .HasColumnType("datetime2(7)");

            // Relación con Role
            entity.HasOne(e => e.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Configuración de la entidad Role
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(e => e.RoleName)
                .IsUnique();

        });

        // Configuración de la entidad TaskItem
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskId);
            
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);
            
            entity.Property(e => e.Description)
                .HasMaxLength(1000);
            
            entity.Property(e => e.Status)
                .HasConversion<int>();
            
            entity.Property(e => e.Priority)
                .HasConversion<int>();
            
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            // Relación con User
            entity.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });


    }


}
