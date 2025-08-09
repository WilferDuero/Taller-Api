using AutoMapper;
using DevWorkshop.TaskAPI.Application.DTOs.Tasks;
using DevWorkshop.TaskAPI.Application.DTOs.Users;
using DevWorkshop.TaskAPI.Domain.Entities;

namespace DevWorkshop.TaskAPI.Application.Mappings;

/// <summary>
/// Perfil de AutoMapper para mapear entidades a DTOs y viceversa
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // TODO: ESTUDIANTE - Configurar mapeos de User
        CreateUserMappings();
        
        // TODO: ESTUDIANTE - Configurar mapeos de TaskItem
        CreateTaskMappings();
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Configurar mapeos para la entidad User
    /// 
    /// Mapeos necesarios:
    /// 1. User -> UserDto (incluir FullName calculado)
    /// 2. CreateUserDto -> User (establecer valores por defecto)
    /// 3. UpdateUserDto -> User (solo campos no nulos)
    /// 
    /// Tips:
    /// - Usar ForMember para mapeos personalizados
    /// - Usar Condition para mapear solo valores no nulos
    /// - FullName se calcula automáticamente en la entidad
    /// </summary>
    private void CreateUserMappings()
    {
        // User -> UserDto
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role != null ? src.Role.RoleName : null));

        // CreateUserDto -> User
        CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Se manejará en el servicio
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.LastTokenIssueAt, opt => opt.Ignore());

        // UpdateUserDto -> User (solo campos no nulos)
        CreateMap<UpdateUserDto, User>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.FirstName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.FirstName)))
            .ForMember(dest => dest.LastName, opt => opt.Condition(src => !string.IsNullOrEmpty(src.LastName)))
            .ForMember(dest => dest.Email, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Email)));
    }

    /// <summary>
    /// TODO: ESTUDIANTE - Configurar mapeos para la entidad TaskItem
    /// 
    /// Mapeos necesarios:
    /// 1. TaskItem -> TaskDto (incluir nombre del usuario creador)
    /// 2. CreateTaskDto -> TaskItem (establecer valores por defecto)
    /// 3. UpdateTaskDto -> TaskItem (solo campos no nulos)
    /// 
    /// Tips:
    /// - Para CreatedByUserName, mapear desde CreatedByUser.FullName
    /// - Usar Condition para campos opcionales
    /// - Status por defecto debe ser Pending
    /// </summary>
    private void CreateTaskMappings()
    {
        // TaskItem -> TaskDto
        CreateMap<TaskItem, TaskDto>()
            .ForMember(dest => dest.CreatedByUserName, 
                opt => opt.MapFrom(src => src.CreatedByUser != null ? src.CreatedByUser.FullName : "Usuario desconocido"));

        // CreateTaskDto -> TaskItem
        CreateMap<CreateTaskDto, TaskItem>()
            .ForMember(dest => dest.TaskId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Domain.Enums.TaskStatus.Pending))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CompletedAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore()) // Se establecerá en el servicio
            .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore());

        // UpdateTaskDto -> TaskItem (solo campos no nulos)
        CreateMap<UpdateTaskDto, TaskItem>()
            .ForMember(dest => dest.TaskId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUserId, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedByUser, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Title, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Title)))
            .ForMember(dest => dest.Description, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Description)))
            .ForMember(dest => dest.Status, opt => opt.Condition(src => src.Status.HasValue))
            .ForMember(dest => dest.Priority, opt => opt.Condition(src => src.Priority.HasValue))
            .ForMember(dest => dest.DueDate, opt => opt.Condition(src => src.DueDate.HasValue))
            .ForMember(dest => dest.IsActive, opt => opt.Condition(src => src.IsActive.HasValue))
            .ForMember(dest => dest.CompletedAt, opt => opt.Condition(src => 
                src.Status.HasValue && src.Status.Value == Domain.Enums.TaskStatus.Completed));
    }
}
