namespace DevWorkshop.TaskAPI.Application.DTOs.Roles;

/// <summary>
/// DTO para mostrar información de un rol
/// </summary>
public class RoleDto
{
    /// <summary>
    /// Identificador único del rol
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Nombre del rol
    /// </summary>
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del rol
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Indica si el rol está activo
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Fecha de creación del rol
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Fecha de última actualización
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Cantidad de usuarios que tienen este rol
    /// </summary>
    public int UserCount { get; set; }
}
