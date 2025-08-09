namespace DevWorkshop.TaskAPI.Application.DTOs.Auth;

/// <summary>
/// DTO para la respuesta de autenticación
/// </summary>
public class AuthResponseDto
{
    /// <summary>
    /// Token JWT generado
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Fecha de expiración del token
    /// </summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>
    /// Información del usuario autenticado
    /// </summary>
    public UserInfo User { get; set; } = new();
}

/// <summary>
/// Información básica del usuario para la respuesta de autenticación
/// </summary>
public class UserInfo
{
    /// <summary>
    /// ID del usuario
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Nombre completo del usuario
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Email del usuario
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
