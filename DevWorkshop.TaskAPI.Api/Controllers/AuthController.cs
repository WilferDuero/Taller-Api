using DevWorkshop.TaskAPI.Application.DTOs.Auth;
using DevWorkshop.TaskAPI.Application.DTOs.Common;
using DevWorkshop.TaskAPI.Application.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevWorkshop.TaskAPI.Api.Controllers;

/// <summary>
/// Controlador para la gestión de autenticación
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
    // TODO: ESTUDIANTE - Inyectar IAuthService, IUserService y ILogger

    public AuthController()
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar el login de usuarios
    /// 
    /// Pasos a seguir:
    /// 1. Validar el modelo LoginDto
    /// 2. Llamar al servicio de autenticación
    /// 3. Si las credenciales son válidas, retornar el token
    /// 4. Si son inválidas, retornar Unauthorized
    /// 5. Manejar excepciones
    /// 
    /// Tip: Este endpoint NO debe tener [Authorize]
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Login([FromBody] LoginDto loginDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica de login
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar el registro de nuevos usuarios
    /// 
    /// Pasos a seguir:
    /// 1. Validar el modelo CreateUserDto
    /// 2. Verificar que el email no esté en uso
    /// 3. Crear el usuario usando IUserService
    /// 4. Generar automáticamente un token para el usuario recién creado
    /// 5. Retornar el token y datos del usuario
    /// 
    /// Tip: Este endpoint tampoco debe tener [Authorize]
    /// </summary>
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), 201)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 409)] // Email ya existe
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Register([FromBody] CreateUserDto createUserDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica de registro
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar endpoint para obtener información del usuario actual
    /// 
    /// Pasos a seguir:
    /// 1. Obtener el UserId del token JWT (User.Claims)
    /// 2. Buscar el usuario usando IUserService
    /// 3. Retornar la información del usuario
    /// 4. Manejar caso donde el usuario no existe
    /// 
    /// Tip: Este endpoint SÍ debe tener [Authorize]
    /// Tip: Usar User.FindFirst(ClaimTypes.NameIdentifier)?.Value para obtener el UserId
    /// </summary>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<UserDto>>> GetCurrentUser()
    {
        // TODO: ESTUDIANTE - Implementar obtención de usuario actual
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar endpoint para verificar si el token es válido
    /// 
    /// Pasos a seguir:
    /// 1. Si el usuario llega a este endpoint, el token es válido
    /// 2. Obtener información básica del token
    /// 3. Retornar confirmación de validez
    /// 
    /// Tip: Este endpoint es útil para que el frontend verifique tokens
    /// </summary>
    [HttpGet("verify")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    public ActionResult<ApiResponse<object>> VerifyToken()
    {
        // TODO: ESTUDIANTE - Implementar verificación de token
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// Endpoint de prueba para verificar que la autenticación funciona
    /// Este endpoint está implementado como ejemplo
    /// </summary>
    [HttpGet("test-auth")]
    [Authorize]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 401)]
    public ActionResult<ApiResponse<object>> TestAuth()
    {
        var userInfo = new
        {
            UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
            Email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value,
            TokenId = User.FindFirst("jti")?.Value,
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false
        };

        return Ok(ApiResponse<object>.SuccessResponse(
            userInfo,
            "Token válido - Usuario autenticado correctamente"
        ));
    }
}
