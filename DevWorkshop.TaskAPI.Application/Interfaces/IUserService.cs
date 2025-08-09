using DevWorkshop.TaskAPI.Application.DTOs.Users;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el servicio de usuarios
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Obtiene todos los usuarios activos
    /// </summary>
    /// <returns>Lista de usuarios</returns>
    Task<IEnumerable<UserDto>> GetAllUsersAsync();

    /// <summary>
    /// Obtiene un usuario por su ID
    /// </summary>
    /// <param name="userId">ID del usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    Task<UserDto?> GetUserByIdAsync(int userId);

    /// <summary>
    /// Obtiene un usuario por su email
    /// </summary>
    /// <param name="email">Email del usuario</param>
    /// <returns>Usuario encontrado o null</returns>
    Task<UserDto?> GetUserByEmailAsync(string email);

    /// <summary>
    /// Crea un nuevo usuario
    /// </summary>
    /// <param name="createUserDto">Datos del usuario a crear</param>
    /// <returns>Usuario creado</returns>
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);

    /// <summary>
    /// Actualiza un usuario existente
    /// </summary>
    /// <param name="userId">ID del usuario a actualizar</param>
    /// <param name="updateUserDto">Datos a actualizar</param>
    /// <returns>Usuario actualizado o null si no existe</returns>
    Task<UserDto?> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);

    /// <summary>
    /// Elimina un usuario (soft delete)
    /// </summary>
    /// <param name="userId">ID del usuario a eliminar</param>
    /// <returns>True si se eliminó correctamente</returns>
    Task<bool> DeleteUserAsync(int userId);

    /// <summary>
    /// Verifica si un email ya está en uso
    /// </summary>
    /// <param name="email">Email a verificar</param>
    /// <param name="excludeUserId">ID de usuario a excluir de la verificación</param>
    /// <returns>True si el email está en uso</returns>
    Task<bool> EmailExistsAsync(string email, int? excludeUserId = null);
}
