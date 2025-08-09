namespace DevWorkshop.TaskAPI.Domain.Entities;

/// <summary>
/// Entidad que representa un rol en el sistema
/// </summary>
public class Role
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
    /// Usuarios que tienen este rol (navegación)
    /// </summary>
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
