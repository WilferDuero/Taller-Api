using DevWorkshop.TaskAPI.Application.DTOs.Auth;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el servicio de autenticación
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Autentica un usuario con email y contraseña
    /// </summary>
    /// <param name="loginDto">Datos de login</param>
    /// <returns>Respuesta de autenticación con token JWT</returns>
    Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);

    /// <summary>
    /// Verifica si una contraseña es válida para un usuario
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <param name="hashedPassword">Contraseña hasheada</param>
    /// <returns>True si la contraseña es válida</returns>
    bool VerifyPassword(string password, string hashedPassword);

    /// <summary>
    /// Genera un hash de contraseña
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <returns>Contraseña hasheada</returns>
    string HashPassword(string password);

    /// <summary>
    /// Genera un token JWT para un usuario
    /// </summary>
    /// <param name="userId">ID del usuario</param>
    /// <param name="email">Email del usuario</param>
    /// <returns>Token JWT</returns>
    string GenerateJwtToken(int userId, string email);
}
