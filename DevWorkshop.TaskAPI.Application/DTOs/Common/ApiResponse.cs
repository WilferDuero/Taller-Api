namespace DevWorkshop.TaskAPI.Application.DTOs.Common;

/// <summary>
/// Respuesta estándar de la API
/// </summary>
/// <typeparam name="T">Tipo de datos que contiene la respuesta</typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// Indica si la operación fue exitosa
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Mensaje descriptivo de la operación
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Datos de la respuesta
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// Lista de errores si los hay
    /// </summary>
    public List<string> Errors { get; set; } = new();

    /// <summary>
    /// Timestamp de la respuesta
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Crea una respuesta exitosa
    /// </summary>
    /// <param name="data">Datos a incluir</param>
    /// <param name="message">Mensaje opcional</param>
    /// <returns>Respuesta exitosa</returns>
    public static ApiResponse<T> SuccessResponse(T data, string message = "Operación exitosa")
    {
        return new ApiResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    /// <summary>
    /// Crea una respuesta de error
    /// </summary>
    /// <param name="message">Mensaje de error</param>
    /// <param name="errors">Lista de errores</param>
    /// <returns>Respuesta de error</returns>
    public static ApiResponse<T> ErrorResponse(string message, List<string>? errors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            Errors = errors ?? new List<string>()
        };
    }

    /// <summary>
    /// Crea una respuesta de error con un solo error
    /// </summary>
    /// <param name="message">Mensaje de error</param>
    /// <param name="error">Error específico</param>
    /// <returns>Respuesta de error</returns>
    public static ApiResponse<T> ErrorResponse(string message, string error)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            Errors = new List<string> { error }
        };
    }
}
