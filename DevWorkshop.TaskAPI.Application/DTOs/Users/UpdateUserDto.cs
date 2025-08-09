using System.ComponentModel.DataAnnotations;

namespace DevWorkshop.TaskAPI.Application.DTOs.Users;

/// <summary>
/// DTO para actualizar un usuario existente
/// </summary>
public class UpdateUserDto
{
    /// <summary>
    /// Nombre del usuario
    /// </summary>
    [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Apellido del usuario
    /// </summary>
    [StringLength(100, ErrorMessage = "El apellido no puede exceder 100 caracteres")]
    public string? LastName { get; set; }

    /// <summary>
    /// Correo electrónico del usuario
    /// </summary>
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [StringLength(255, ErrorMessage = "El email no puede exceder 255 caracteres")]
    public string? Email { get; set; }

    /// <summary>
    /// ID del rol del usuario
    /// </summary>
    public int? RoleId { get; set; }

    /// <summary>
    /// ID del equipo del usuario
    /// </summary>
    public int? TeamId { get; set; }
}
