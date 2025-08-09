namespace DevWorkshop.TaskAPI.Application.DTOs.Users;

/// <summary>
/// DTO para mostrar información de un usuario
/// </summary>
public class UserDto
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
    /// Correo electrónico del usuario
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Nombre completo del usuario
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// ID del rol del usuario
    /// </summary>
    public int? RoleId { get; set; }

    /// <summary>
    /// Nombre del rol del usuario
    /// </summary>
    public string? RoleName { get; set; }

    /// <summary>
    /// ID del equipo del usuario
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Fecha de creación del usuario
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha de última actualización
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
