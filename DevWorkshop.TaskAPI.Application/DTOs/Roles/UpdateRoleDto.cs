using System.ComponentModel.DataAnnotations;

namespace DevWorkshop.TaskAPI.Application.DTOs.Roles;

/// <summary>
/// DTO para actualizar un rol existente
/// </summary>
public class UpdateRoleDto
{
    /// <summary>
    /// Nombre del rol
    /// </summary>
    [StringLength(50, ErrorMessage = "El nombre del rol no puede exceder 50 caracteres")]
    public string? RoleName { get; set; }

    /// <summary>
    /// Descripción del rol
    /// </summary>
    [StringLength(200, ErrorMessage = "La descripción no puede exceder 200 caracteres")]
    public string? Description { get; set; }
}
