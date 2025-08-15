using DevWorkshop.TaskAPI.Application.DTOs.Auth;
using DevWorkshop.TaskAPI.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevWorkshop.TaskAPI.Application.Services;

/// <summary>
/// Servicio para la gestión de autenticación
/// </summary>
public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;
    // TODO: ESTUDIANTE - Inyectar dependencias necesarias (IUserService, IConfiguration, Logger)

    public AuthService(IUserService userService, IConfiguration configuration, ILogger<AuthService> logger)
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
        _userService = userService;
        _configuration = configuration;
        _logger = logger;
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
        try
        {
            _logger.LogInformation("Iniciando proceso de autenticación para email: {Email}", loginDto.Email);

            // Buscar usuario por email
            var user = await _userService.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                _logger.LogWarning("Usuario no encontrado con email: {Email}", loginDto.Email);
                return null;
            }

            // Obtener entidad completa para verificar contraseña
            var userEntity = await _userService.GetUserEntityByEmailAsync(loginDto.Email);
            if (userEntity == null)
            {
                _logger.LogWarning("Entidad de usuario no encontrada para email: {Email}", loginDto.Email);
                return null;
            }

            // Verificar contraseña
            if (!VerifyPassword(loginDto.Password, userEntity.PasswordHash))
            {
                _logger.LogWarning("Contraseña incorrecta para usuario: {Email}", loginDto.Email);
                return null;
            }

            // Generar token JWT
            var token = GenerateJwtToken(user.UserId, user.Email, user.RoleName);
            var expirationTime = DateTime.UtcNow.AddMinutes(GetJwtExpirationMinutes());

            // Crear respuesta de autenticación
            var authResponse = new AuthResponseDto
            {
                Token = token,
                ExpiresAt = expirationTime,
                User = new UserInfo
                {
                    UserId = user.UserId,
                    FullName = user.FullName,
                    Email = user.Email
                }
            };

            _logger.LogInformation("Autenticación exitosa para usuario: {Email}", loginDto.Email);
            return authResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error durante el proceso de autenticación para email: {Email}", loginDto.Email);
            return null;
        }
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
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al verificar contraseña");
            return false;
        }
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
        try
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al generar hash de contraseña");
            throw;
        }
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
   
        // TODO: ESTUDIANTE - Implementar generación de JWT
     public string GenerateJwtToken(int userId, string email, string? roleName = null)
    {
        try
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!);
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expirationMinutes = int.Parse(jwtSettings["ExpirationInMinutes"]!);

            // Crear claims del usuario
            var claimsList = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim("jti", Guid.NewGuid().ToString()),
                new Claim("iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            // Agregar rol si está disponible
            if (!string.IsNullOrEmpty(roleName))
            {
                claimsList.Add(new Claim(ClaimTypes.Role, roleName));
            }

            var claims = claimsList.ToArray();

            // Configurar token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            _logger.LogInformation("Token JWT generado exitosamente para usuario: {UserId}", userId);
            return tokenHandler.WriteToken(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al generar token JWT para usuario: {UserId}", userId);
            throw;
        }
    
    }

   
    private int GetJwtExpirationMinutes()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        return int.Parse(jwtSettings["ExpirationInMinutes"] ?? "60");
    }

    public Task<bool> LogoutAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
