using AutoMapper;
using DevWorkshop.TaskAPI.Application.DTOs.Roles;
using DevWorkshop.TaskAPI.Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace DevWorkshop.TaskAPI.Application.Services;

/// <summary>
/// Servicio para la gestión de roles - IMPLEMENTADO COMO EJEMPLO
/// Este servicio está en Application y usa Unit of Work (Arquitectura Limpia)
/// </summary>
public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<RoleService> _logger;

    public RoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RoleService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// EJEMPLO IMPLEMENTADO: Obtiene todos los roles activos
    /// 
    /// Este método está completamente implementado como ejemplo para que los estudiantes
    /// vean cómo debe estructurarse un servicio completo.
    /// </summary>
    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        try
        {
            _logger.LogInformation("Obteniendo todos los roles activos");

            var roles = await _unitOfWork.Roles.GetAllAsync();

            var roleDtos = new List<RoleDto>();

            foreach (var role in roles)
            {
                // Contar usuarios para este rol
                var userCount = await _unitOfWork.Users.CountAsync(u => u.RoleId == role.RoleId);

                roleDtos.Add(new RoleDto
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName,
                    Description = $"Rol {role.RoleName}",
                    IsActive = true, // Por defecto todos los roles están activos
                    CreatedAt = DateTime.UtcNow, // Valor por defecto
                    UserCount = userCount
                });
            }

            _logger.LogInformation("Se obtuvieron {Count} roles", roleDtos.Count());
            return roleDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener los roles");
            throw;
        }
    }

    /// <summary>
    /// EJEMPLO IMPLEMENTADO: Obtiene un rol por su ID
    /// 
    /// Este método también está implementado como ejemplo de buenas prácticas.
    /// </summary>
    public async Task<RoleDto?> GetRoleByIdAsync(int roleId)
    {
        try
        {
            _logger.LogInformation("Buscando rol con ID: {RoleId}", roleId);

            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);

            if (role == null)
            {
                _logger.LogWarning("No se encontró el rol con ID: {RoleId}", roleId);
                return null;
            }

            // Contar usuarios para este rol
            var userCount = await _unitOfWork.Users.CountAsync(u => u.RoleId == role.RoleId);

            var roleDto = new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Description = $"Rol {role.RoleName}",
                IsActive = true, // Por defecto todos los roles están activos
                CreatedAt = DateTime.UtcNow, // Valor por defecto
                UserCount = userCount
            };

            _logger.LogInformation("Rol encontrado: {RoleName}", role.RoleName);
            return roleDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar el rol con ID: {RoleId}", roleId);
            throw;
        }
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar creación de rol
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el nombre del rol no exista
    /// 2. Crear nueva entidad Role
    /// 3. Usar _unitOfWork.Roles.AddAsync()
    /// 4. Llamar _unitOfWork.SaveChangesAsync()
    /// 5. Mapear y retornar RoleDto
    /// </summary>
    public async Task<RoleDto> CreateRoleAsync(CreateRoleDto createRoleDto)
    {
        // TODO: ESTUDIANTE - Implementar
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar actualización de rol
    /// 
    /// Pasos a seguir:
    /// 1. Buscar rol existente por ID
    /// 2. Validar que existe
    /// 3. Actualizar propiedades
    /// 4. Usar _unitOfWork.Roles.Update()
    /// 5. Llamar _unitOfWork.SaveChangesAsync()
    /// 6. Mapear y retornar RoleDto
    /// </summary>
    public async Task<RoleDto?> UpdateRoleAsync(int roleId, UpdateRoleDto updateRoleDto)
    {
        // TODO: ESTUDIANTE - Implementar
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar eliminación de rol
    /// 
    /// Pasos a seguir:
    /// 1. Buscar rol existente por ID
    /// 2. Validar que existe
    /// 3. Verificar que no tenga usuarios asignados
    /// 4. Usar _unitOfWork.Roles.Remove()
    /// 5. Llamar _unitOfWork.SaveChangesAsync()
    /// 6. Retornar true si se eliminó correctamente
    /// </summary>
    public async Task<bool> DeleteRoleAsync(int roleId)
    {
        // TODO: ESTUDIANTE - Implementar
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// EJEMPLO IMPLEMENTADO: Obtiene estadísticas de roles
    /// </summary>
    public async Task<RoleStatisticsDto> GetRoleStatisticsAsync()
    {
        try
        {
            _logger.LogInformation("Obteniendo estadísticas de roles");

            var totalRoles = await _unitOfWork.Roles.CountAsync();
            var totalUsers = await _unitOfWork.Users.CountAsync();
            var usersWithoutRole = await _unitOfWork.Users.CountAsync(u => u.RoleId == null);

            return new RoleStatisticsDto
            {
                TotalRoles = totalRoles,
                TotalUsers = totalUsers,
                UsersWithoutRole = usersWithoutRole,
                UsersWithRole = totalUsers - usersWithoutRole
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener estadísticas de roles");
            throw;
        }
    }
}
