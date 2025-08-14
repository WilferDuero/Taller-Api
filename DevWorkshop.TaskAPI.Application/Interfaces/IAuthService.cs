using DevWorkshop.TaskAPI.Application.DTOs.Auth;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el servicio de autenticación
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Autentica un usuario mediante email y contraseña
    /// </summary>
    /// <param name="loginDto">Datos de autenticación</param>
    /// <returns>Respuesta de autenticación con token JWT o null si las credenciales son inválidas</returns>
    Task<AuthResponseDto?> LoginAsync(LoginDto loginDto);

    /// <summary>
    /// Verifica la validez de una contraseña
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <param name="hashedPassword">Contraseña hasheada</param>
    /// <returns>True si la contraseña es válida</returns>
    bool VerifyPassword(string password, string hashedPassword);

    /// <summary>
    /// Genera un hash seguro de contraseña
    /// </summary>
    /// <param name="password">Contraseña en texto plano</param>
    /// <returns>Contraseña hasheada</returns>
    string HashPassword(string password);

    /// <summary>
    /// Genera un token JWT para un usuario
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <param name="email">Email del usuario</param>
    /// <param name="roleName">Nombre del rol del usuario</param>
    /// <returns>Token JWT como string</returns>
    string GenerateJwtToken(int userId, string email, string? roleName = null);

    /// <summary>
    /// Cierra la sesión de un usuario invalidando su token
    /// </summary>
    /// <param name="userId">Identificador del usuario</param>
    /// <returns>True si el logout fue exitoso</returns>
    Task<bool> LogoutAsync(int userId);
}