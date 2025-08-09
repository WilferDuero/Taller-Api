using DevWorkshop.TaskAPI.Application.DTOs.Auth;
using DevWorkshop.TaskAPI.Application.Interfaces;

namespace DevWorkshop.TaskAPI.Application.Services;

/// <summary>
/// Servicio para la gestión de autenticación
/// </summary>
public class AuthService : IAuthService
{
    // TODO: ESTUDIANTE - Inyectar dependencias necesarias (IUserService, IConfiguration, Logger)
    
    public AuthService()
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar el login de usuarios
    /// 
    /// Pasos a seguir:
    /// 1. Buscar el usuario por email usando IUserService
    /// 2. Verificar que el usuario existe y está activo
    /// 3. Verificar la contraseña usando VerifyPassword
    /// 4. Si las credenciales son válidas, generar un token JWT
    /// 5. Crear y retornar AuthResponseDto con el token y datos del usuario
    /// 6. Si las credenciales son inválidas, retornar null
    /// 
    /// Tip: Usar BCrypt para verificar contraseñas
    /// </summary>
    public async Task<AuthResponseDto?> LoginAsync(LoginDto loginDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica de autenticación
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la verificación de contraseñas
    /// 
    /// Pasos a seguir:
    /// 1. Usar BCrypt.Net.BCrypt.Verify para comparar la contraseña
    /// 2. Retornar true si la contraseña coincide
    /// 
    /// Tip: BCrypt.Net.BCrypt.Verify(password, hashedPassword)
    /// </summary>
    public bool VerifyPassword(string password, string hashedPassword)
    {
        // TODO: ESTUDIANTE - Implementar verificación de contraseña
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar el hash de contraseñas
    /// 
    /// Pasos a seguir:
    /// 1. Usar BCrypt.Net.BCrypt.HashPassword para generar el hash
    /// 2. Retornar la contraseña hasheada
    /// 
    /// Tip: BCrypt.Net.BCrypt.HashPassword(password)
    /// </summary>
    public string HashPassword(string password)
    {
        // TODO: ESTUDIANTE - Implementar hash de contraseña
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la generación de tokens JWT
    /// 
    /// Pasos a seguir:
    /// 1. Obtener la configuración JWT desde IConfiguration
    /// 2. Crear claims para el usuario (UserId, Email, etc.)
    /// 3. Crear el token usando JwtSecurityTokenHandler
    /// 4. Configurar la expiración del token
    /// 5. Retornar el token como string
    /// 
    /// Claims sugeridos:
    /// - ClaimTypes.NameIdentifier (UserId)
    /// - ClaimTypes.Email (Email)
    /// - "jti" (Token ID único)
    /// 
    /// Tip: Usar System.IdentityModel.Tokens.Jwt
    /// </summary>
    public string GenerateJwtToken(int userId, string email)
    {
        // TODO: ESTUDIANTE - Implementar generación de JWT
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }
}
