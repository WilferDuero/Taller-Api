using DevWorkshop.TaskAPI.Application.DTOs.Common;
using DevWorkshop.TaskAPI.Application.DTOs.Users;
using DevWorkshop.TaskAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevWorkshop.TaskAPI.Api.Controllers;

/// <summary>
/// Controlador para la gestión de usuarios
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UsersController : ControllerBase
{
    // TODO: ESTUDIANTE - Inyectar IUserService y ILogger
    
    public UsersController()
    {
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de todos los usuarios
    ///
    /// Pasos a seguir:
    /// 1. Llamar al servicio para obtener todos los usuarios
    /// 2. Retornar ApiResponse con la lista de usuarios
    /// 3. Manejar excepciones con try-catch
    /// 4. Retornar respuesta de error si algo falla
    ///
    /// Tip: Usar [Authorize] para proteger este endpoint
    /// </summary>
    [HttpGet("getAll")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<UserDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAllUsers()
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de un usuario por ID
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido (> 0)
    /// 2. Llamar al servicio para buscar el usuario
    /// 3. Si no existe, retornar NotFound
    /// 4. Si existe, retornar Ok con el usuario
    /// 5. Manejar excepciones
    /// </summary>
    [HttpGet("getById/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<UserDto>>> GetUserById(int id)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la creación de un nuevo usuario
    /// 
    /// Pasos a seguir:
    /// 1. Validar el modelo usando ModelState
    /// 2. Verificar que el email no esté en uso
    /// 3. Llamar al servicio para crear el usuario
    /// 4. Retornar Created con el usuario creado
    /// 5. Manejar excepciones y errores de validación
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 201)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 409)] // Conflict - email ya existe
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<UserDto>>> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la actualización de un usuario
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Validar el modelo si tiene datos
    /// 3. Verificar que el usuario existe
    /// 4. Si se actualiza email, verificar que no esté en uso
    /// 5. Llamar al servicio para actualizar
    /// 6. Retornar Ok con el usuario actualizado
    /// </summary>
    [HttpPut("update/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 409)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<UserDto>>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la eliminación de un usuario
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el ID sea válido
    /// 2. Verificar que el usuario existe
    /// 3. Llamar al servicio para eliminar (soft delete)
    /// 4. Retornar NoContent si se eliminó correctamente
    /// 5. Retornar NotFound si no existe
    /// </summary>
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(ApiResponse<object>), 204)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<object>>> DeleteUser(int id)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la búsqueda de usuario por email
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el email tenga formato válido
    /// 2. Llamar al servicio para buscar por email
    /// 3. Retornar el usuario si existe
    /// 4. Retornar NotFound si no existe
    /// </summary>
    [HttpGet("getByEmail/{email}")]
    [ProducesResponseType(typeof(ApiResponse<UserDto>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 404)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<UserDto>>> GetUserByEmail(string email)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }



    /// <summary>
    /// TODO: ESTUDIANTE - Obtener usuarios por rol
    ///
    /// Endpoint para filtrar usuarios por rol específico.
    /// Pasos a seguir:
    /// 1. Validar que el roleId sea válido
    /// 2. Llamar al servicio para obtener usuarios del rol
    /// 3. Retornar lista de usuarios (puede estar vacía)
    /// </summary>
    [HttpGet("getByRole/{roleId:int}")]
    [ProducesResponseType(typeof(ApiResponse<IEnumerable<UserDto>>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 400)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetUsersByRole(int roleId)
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Obtener estadísticas de usuarios
    ///
    /// Endpoint para dashboard y reportes.
    /// Debe retornar información como:
    /// - Total de usuarios
    /// - Usuarios por rol
    /// - Usuarios creados en el último mes
    /// - etc.
    /// </summary>
    [HttpGet("getStatistics")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    [ProducesResponseType(typeof(ApiResponse<object>), 500)]
    public async Task<ActionResult<ApiResponse<object>>> GetUserStatistics()
    {
        // TODO: ESTUDIANTE - Implementar lógica del controlador
        throw new NotImplementedException("Endpoint pendiente de implementación por el estudiante");
    }
}
