using System.ComponentModel.DataAnnotations;

namespace DevWorkshop.TaskAPI.Application.DTOs.Roles;

/// <summary>
/// DTO para crear un nuevo rol
/// </summary>
public class CreateRoleDto
{
    /// <summary>
    /// Nombre del rol
    /// </summary>
    [Required(ErrorMessage = "El nombre del rol es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre del rol no puede exceder 50 caracteres")]
    public string RoleName { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del rol
    /// </summary>
    [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
    public string? Description { get; set; }
}
