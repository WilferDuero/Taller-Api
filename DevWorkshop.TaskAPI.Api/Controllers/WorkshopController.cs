using DevWorkshop.TaskAPI.Application.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace DevWorkshop.TaskAPI.Api.Controllers;

/// <summary>
/// Controlador para información del taller y endpoints de demostración
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class WorkshopController : ControllerBase
{
    /// <summary>
    /// Obtiene información general del taller
    /// </summary>
    /// <returns>Información del taller DevWorkshop TaskAPI</returns>
    [HttpGet("info")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    public ActionResult<ApiResponse<object>> GetWorkshopInfo()
    {
        var workshopInfo = new
        {
            Title = "DevWorkshop - TaskAPI",
            Description = "Taller práctico para aprender desarrollo de APIs REST con .NET 9",
            Version = "1.0.0",
            Technologies = new[]
            {
                ".NET 9",
                "Entity Framework Core 9.0.8",
                "JWT Authentication",
                "AutoMapper 12.0.1",
                "Swagger/OpenAPI",
                "SQL Server (Azure)"
            },
            Features = new[]
            {
                "CRUD completo de usuarios",
                "Sistema de autenticación con JWT",
                "CRUD básico de tareas",
                "Arquitectura limpia",
                "Documentación automática con Swagger",
                "Validaciones de datos",
                "Manejo de errores",
                "Respuestas estandarizadas"
            },
            LearningObjectives = new[]
            {
                "Crear APIs REST con .NET 9",
                "Implementar autenticación JWT",
                "Usar Entity Framework Core",
                "Aplicar arquitectura limpia",
                "Manejar validaciones y errores",
                "Documentar APIs con Swagger",
                "Trabajar con bases de datos en Azure"
            },
            DatabaseConnection = "Conectado a DesarrolloWebDb en Azure",
            Author = "DevWorkshop Team",
            Contact = "admin@devworkshop.com"
        };

        return Ok(ApiResponse<object>.SuccessResponse(
            workshopInfo, 
            "¡Bienvenido al taller DevWorkshop TaskAPI!"
        ));
    }

    /// <summary>
    /// Verifica el estado de la conexión a la base de datos
    /// </summary>
    /// <returns>Estado de la conexión</returns>
    [HttpGet("health")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    public ActionResult<ApiResponse<object>> GetHealthStatus()
    {
        // TODO: ESTUDIANTE - Implementar verificación real de la base de datos
        // Tip: Inyectar ApplicationDbContext y hacer una consulta simple
        
        var healthInfo = new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Database = "Connected to DesarrolloWebDb",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production",
            Version = "1.0.0"
        };

        return Ok(ApiResponse<object>.SuccessResponse(
            healthInfo, 
            "API funcionando correctamente"
        ));
    }

    /// <summary>
    /// Obtiene las tareas pendientes del taller para los estudiantes
    /// </summary>
    /// <returns>Lista de tareas a implementar</returns>
    [HttpGet("tasks")]
    [ProducesResponseType(typeof(ApiResponse<object>), 200)]
    public ActionResult<ApiResponse<object>> GetWorkshopTasks()
    {
        var tasks = new
        {
            PendingImplementations = new[]
            {
                new { 
                    Module = "UserService", 
                    Tasks = new[] {
                        "Implementar GetAllUsersAsync()",
                        "Implementar GetUserByIdAsync()",
                        "Implementar CreateUserAsync()",
                        "Implementar UpdateUserAsync()",
                        "Implementar DeleteUserAsync()"
                    }
                },
                new { 
                    Module = "AuthService", 
                    Tasks = new[] {
                        "Implementar LoginAsync()",
                        "Implementar VerifyPassword()",
                        "Implementar HashPassword()",
                        "Implementar GenerateJwtToken()"
                    }
                },
                new { 
                    Module = "TaskService", 
                    Tasks = new[] {
                        "Implementar GetAllTasksAsync()",
                        "Implementar CreateTaskAsync()",
                        "Implementar UpdateTaskAsync()",
                        "Implementar CompleteTaskAsync()"
                    }
                },
                new { 
                    Module = "Controllers", 
                    Tasks = new[] {
                        "Implementar UsersController endpoints",
                        "Implementar AuthController endpoints",
                        "Implementar TasksController endpoints",
                        "Agregar validaciones y manejo de errores"
                    }
                }
            },
            Instructions = new[]
            {
                "1. Revisar los comentarios TODO en cada archivo",
                "2. Implementar los métodos siguiendo las instrucciones",
                "3. Probar cada endpoint usando Swagger",
                "4. Verificar que las validaciones funcionen",
                "5. Manejar errores apropiadamente"
            },
            Tips = new[]
            {
                "Usar async/await para operaciones de base de datos",
                "Implementar validaciones en los DTOs",
                "Usar AutoMapper para mapear entidades",
                "Manejar excepciones con try-catch",
                "Retornar respuestas consistentes con ApiResponse<T>"
            }
        };

        return Ok(ApiResponse<object>.SuccessResponse(
            tasks, 
            "Tareas pendientes del taller"
        ));
    }
}
