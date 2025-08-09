namespace DevWorkshop.TaskAPI.Domain.Entities;

/// <summary>
/// Entidad que representa un usuario en el sistema
/// </summary>
public class User
{
    /// <summary>
    /// Identificador único del usuario
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Nombre del usuario
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Apellido del usuario
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Correo electrónico del usuario (único)
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña hasheada del usuario
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// ID del rol del usuario
    /// </summary>
    public int? RoleId { get; set; }

    /// <summary>
    /// ID del equipo del usuario
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Fecha del último token emitido
    /// </summary>
    public DateTime? LastTokenIssueAt { get; set; }

    /// <summary>
    /// Fecha de creación del usuario
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Fecha de última actualización
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Rol del usuario (navegación)
    /// </summary>
    public virtual Role? Role { get; set; }

    /// <summary>
    /// Nombre completo del usuario (propiedad calculada)
    /// </summary>
    public string FullName => $"{FirstName} {LastName}".Trim();
}
