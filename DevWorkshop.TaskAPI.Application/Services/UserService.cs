using AutoMapper;
using DevWorkshop.TaskAPI.Application.DTOs.Users;
using DevWorkshop.TaskAPI.Application.Interfaces;
using DevWorkshop.TaskAPI.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DevWorkshop.TaskAPI.Application.Services;

/// <summary>
/// Servicio para la gestión de usuarios
/// </summary>
public class UserService : IUserService
{
    // TODO: ESTUDIANTE - Inyectar dependencias necesarias (DbContext, AutoMapper, Logger)
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    
    public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }
        // TODO: ESTUDIANTE - Configurar las dependencias inyectadas
    

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la obtención de todos los usuarios activos
    /// 
    /// Pasos a seguir:
    /// 1. Consultar la base de datos para obtener usuarios donde IsActive = true
    /// 2. Mapear las entidades User a UserDto usando AutoMapper
    /// 3. Retornar la lista de usuarios
    /// 
    /// Tip: Usar async/await y ToListAsync() para operaciones asíncronas
    /// </summary>
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la búsqueda de usuario por ID
    /// 
    /// Pasos a seguir:
    /// 1. Buscar el usuario en la base de datos por UserId
    /// 2. Verificar que el usuario existe y está activo
    /// 3. Mapear la entidad a UserDto
    /// 4. Retornar el usuario o null si no existe
    /// </summary>
    public async Task<UserDto?> GetUserByIdAsync(int userId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la búsqueda de usuario por email
    /// 
    /// Pasos a seguir:
    /// 1. Buscar el usuario en la base de datos por Email
    /// 2. Verificar que el usuario existe y está activo
    /// 3. Mapear la entidad a UserDto
    /// 4. Retornar el usuario o null si no existe
    /// </summary>
    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        try
        {
            _logger.LogInformation("Buscando usuario por email: {Email}", email);

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                _logger.LogInformation("No se encontró usuario con email: {Email}", email);
                return null;
            }

            var userDto = _mapper.Map<UserDto>(user);

            _logger.LogInformation("Usuario encontrado con ID: {UserId}", user.UserId);
            return userDto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar usuario por email: {Email}", email);
            throw;
        }
    }
    

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la creación de un nuevo usuario
    /// 
    /// Pasos a seguir:
    /// 1. Validar que el email no esté en uso
    /// 2. Hashear la contraseña usando BCrypt
    /// 3. Crear una nueva entidad User con los datos del DTO
    /// 4. Establecer CreatedAt = DateTime.UtcNow e IsActive = true
    /// 5. Guardar en la base de datos
    /// 6. Mapear la entidad creada a UserDto y retornar
    /// </summary>
    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        try
        {
            var emailformat = createUserDto.Email.Trim().ToLower();
            var validuser = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == emailformat);
            if (validuser != null)
            {
                throw new InvalidCastException("Usuario ya creado");
            }

            var passwordHasch = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

            var user = _mapper.Map<User>(createUserDto);
            user.Email = emailformat;
            user.PasswordHash = passwordHasch;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.LastTokenIssueAt = DateTime.Now;
            user.RoleId = 4;


            var createUser = await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDto>(createUser);

        }
        catch (Exception ex)
        {
            throw;
        }
        
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la actualización de un usuario
    /// 
    /// Pasos a seguir:
    /// 1. Buscar el usuario existente por ID
    /// 2. Verificar que el usuario existe
    /// 3. Si se actualiza el email, validar que no esté en uso por otro usuario
    /// 4. Actualizar solo los campos que no sean null en el DTO
    /// 5. Establecer UpdatedAt = DateTime.UtcNow
    /// 6. Guardar cambios en la base de datos
    /// 7. Mapear y retornar el usuario actualizado
    /// </summary>
    public async Task<UserDto?> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la eliminación lógica de un usuario
    /// 
    /// Pasos a seguir:
    /// 1. Buscar el usuario por ID
    /// 2. Verificar que el usuario existe
    /// 3. Establecer IsActive = false (soft delete)
    /// 4. Establecer UpdatedAt = DateTime.UtcNow
    /// 5. Guardar cambios en la base de datos
    /// 6. Retornar true si se eliminó correctamente
    /// </summary>
    public async Task<bool> DeleteUserAsync(int userId)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Implementar la verificación de email existente
    /// 
    /// Pasos a seguir:
    /// 1. Buscar usuarios con el email especificado
    /// 2. Si se proporciona excludeUserId, excluir ese usuario de la búsqueda
    /// 3. Retornar true si existe algún usuario con ese email
    /// </summary>
    public async Task<bool> EmailExistsAsync(string email, int? excludeUserId = null)
    {
        // TODO: ESTUDIANTE - Implementar lógica
        throw new NotImplementedException("Método pendiente de implementación por el estudiante");
    }

    Task<IEnumerable<UserDto>> IUserService.GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    Task<UserDto?> IUserService.GetUserByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    Task<UserDto?> IUserService.GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    Task<UserDto> IUserService.CreateUserAsync(CreateUserDto createUserDto)
    {
        throw new NotImplementedException();
    }

    Task<UserDto?> IUserService.UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    Task<bool> IUserService.DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    Task<bool> IUserService.EmailExistsAsync(string email, int? excludeUserId)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserService.GetUserEntityByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    Task<User?> IUserService.GetUserEntityByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    Task<bool> IUserService.UpdateUserEntityAsync(User user)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Obtiene la entidad User completa por email
    /// </summary>
    public async Task<User?> GetUserEntityByEmailAsync(string email)
    {
        try
        {
            _logger.LogInformation("Buscando entidad User por email: {Email}", email);

            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                _logger.LogInformation("Entidad User encontrada para email: {Email}", email);
            }
            else
            {
                _logger.LogInformation("No se encontró entidad User para email: {Email}", email);
            }

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar entidad User por email: {Email}", email);
            throw;
        }
    }

    /// <summary>
    /// Obtiene la entidad User completa por ID
    /// </summary>
    public async Task<User?> GetUserEntityByIdAsync(int userId)
    {
        try
        {
            _logger.LogInformation("Buscando entidad User por ID: {UserId}", userId);

            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (user != null)
            {
                _logger.LogInformation("Entidad User encontrada para ID: {UserId}", userId);
            }
            else
            {
                _logger.LogInformation("No se encontró entidad User para ID: {UserId}", userId);
            }

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al buscar entidad User por ID: {UserId}", userId);
            throw;
        }
    }

    /// <summary>
    /// Actualiza una entidad User en la base de datos
    /// </summary>
    public async Task<bool> UpdateUserEntityAsync(User user)
    {
        try
        {
            _logger.LogInformation("Actualizando entidad User con ID: {UserId}", user.UserId);

            _unitOfWork.Users.Update(user);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogInformation("Entidad User actualizada exitosamente: {UserId}", user.UserId);
                return true;
            }
            else
            {
                _logger.LogWarning("No se pudo actualizar la entidad User: {UserId}", user.UserId);
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar entidad User: {UserId}", user.UserId);
            throw;
        }
    }
}
