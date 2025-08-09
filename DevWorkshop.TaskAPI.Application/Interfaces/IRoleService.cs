using DevWorkshop.TaskAPI.Application.DTOs.Roles;

namespace DevWorkshop.TaskAPI.Application.Interfaces;

/// <summary>
/// Interfaz para el servicio de roles
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Obtiene todos los roles activos
    /// </summary>
    /// <returns>Lista de roles</returns>
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();

    /// <summary>
    /// Obtiene un rol por su ID
    /// </summary>
    /// <param name="roleId">ID del rol</param>
    /// <returns>Rol encontrado o null</returns>
    Task<RoleDto?> GetRoleByIdAsync(int roleId);

    /// <summary>
    /// Crea un nuevo rol
    /// </summary>
    /// <param name="createRoleDto">Datos del rol a crear</param>
    /// <returns>Rol creado</returns>
    Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto);

    /// <summary>
    /// Actualiza un rol existente
    /// </summary>
    /// <param name="roleId">ID del rol a actualizar</param>
    /// <param name="updateRoleDto">Datos a actualizar</param>
    /// <returns>Rol actualizado o null si no existe</returns>
    Task<RoleDto?> UpdateRoleAsync(int roleId, UpdateRoleDto updateRoleDto);

    /// <summary>
    /// Elimina un rol
    /// </summary>
    /// <param name="roleId">ID del rol a eliminar</param>
    /// <returns>True si se eliminó correctamente</returns>
    Task<bool> DeleteRoleAsync(int roleId);

    /// <summary>
    /// Obtiene estadísticas de roles
    /// </summary>
    /// <returns>Estadísticas de roles</returns>
    Task<RoleStatisticsDto> GetRoleStatisticsAsync();
}
