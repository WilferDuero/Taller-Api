# 🚀 DevWorkshop TaskAPI

**Taller práctico para aprender desarrollo de APIs REST con .NET 9**

## 📋 Descripción del Proyecto

DevWorkshop TaskAPI es un proyecto educativo diseñado para enseñar desarrollo web con .NET 9, implementando una API REST completa con autenticación JWT y arquitectura limpia.

### 🎯 Objetivos de Aprendizaje

- ✅ Crear APIs REST con .NET 9
- ✅ Implementar autenticación JWT
- ✅ Usar Entity Framework Core con SQL Server
- ✅ Aplicar arquitectura limpia
- ✅ Manejar validaciones y errores
- ✅ Documentar APIs con Swagger
- ✅ Trabajar con bases de datos en Azure

## 🏗️ Arquitectura del Proyecto

```
📁 DevWorkshop.TaskAPI/
├── 📁 DevWorkshop.TaskAPI.Domain/          # Entidades y enums
├── 📁 DevWorkshop.TaskAPI.Application/     # DTOs, servicios e interfaces
├── 📁 DevWorkshop.TaskAPI.Infrastructure/  # Entity Framework y repositorios
└── 📁 DevWorkshop.TaskAPI.Api/             # Controllers y configuración
```

### 🔧 Tecnologías Utilizadas

- **.NET 9** - Framework principal
- **Entity Framework Core 9.0.8** - ORM
- **SQL Server (Azure)** - Base de datos
- **JWT Authentication** - Seguridad
- **AutoMapper 12.0.1** - Mapeo de objetos
- **Swagger/OpenAPI** - Documentación
- **Arquitectura Limpia** - Separación de responsabilidades

## 🗄️ Base de Datos

**Conexión:** `DesarrolloWebDb` en Azure SQL Server
**Servidor:** `servidor-clase-web-dev.database.windows.net`

### Entidades Principales:
- **Users** - Gestión de usuarios
- **Tasks** - Gestión de tareas

## 🚀 Cómo Ejecutar el Proyecto

### Prerrequisitos
- .NET 9 SDK
- Visual Studio 2022 o VS Code
- Acceso a la base de datos Azure (ya configurado)

### Pasos para Ejecutar

1. **Clonar/Abrir el proyecto**
   ```bash
   cd DevWorkshop.TaskAPI
   ```

2. **Restaurar paquetes**
   ```bash
   dotnet restore
   ```

3. **Compilar el proyecto**
   ```bash
   dotnet build
   ```

4. **Ejecutar la API**
   ```bash
   dotnet run --project DevWorkshop.TaskAPI.Api
   ```

5. **Abrir Swagger**
   - La API se ejecuta en: `https://localhost:7xxx`
   - Swagger UI está disponible en la raíz: `https://localhost:7xxx`

## 📚 Endpoints Disponibles

### 🔍 Información del Taller
- `GET /api/workshop/info` - Información general del taller
- `GET /api/workshop/health` - Estado de la API
- `GET /api/workshop/tasks` - Tareas pendientes para estudiantes

### 👥 Gestión de Usuarios (TODO)
- `GET /api/users` - Obtener todos los usuarios
- `GET /api/users/{id}` - Obtener usuario por ID
- `POST /api/users` - Crear nuevo usuario
- `PUT /api/users/{id}` - Actualizar usuario
- `DELETE /api/users/{id}` - Eliminar usuario

### 🔐 Autenticación (TODO)
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/auth/register` - Registrar nuevo usuario
- `GET /api/auth/me` - Información del usuario actual
- `GET /api/auth/verify` - Verificar token

### 📋 Gestión de Tareas (TODO)
- `GET /api/tasks` - Obtener todas las tareas
- `GET /api/tasks/{id}` - Obtener tarea por ID
- `POST /api/tasks` - Crear nueva tarea
- `PUT /api/tasks/{id}` - Actualizar tarea
- `DELETE /api/tasks/{id}` - Eliminar tarea

## 🎓 Tareas para Estudiantes

### 📝 Implementaciones Pendientes

#### 1. **UserService** (Prioridad Alta)
- [ ] `GetAllUsersAsync()` - Obtener todos los usuarios
- [ ] `GetUserByIdAsync()` - Buscar usuario por ID
- [ ] `CreateUserAsync()` - Crear nuevo usuario
- [ ] `UpdateUserAsync()` - Actualizar usuario existente
- [ ] `DeleteUserAsync()` - Eliminación lógica

#### 2. **AuthService** (Prioridad Alta)
- [ ] `LoginAsync()` - Autenticación de usuarios
- [ ] `VerifyPassword()` - Verificación de contraseñas
- [ ] `HashPassword()` - Hash de contraseñas con BCrypt
- [ ] `GenerateJwtToken()` - Generación de tokens JWT

#### 3. **TaskService** (Prioridad Media)
- [ ] `GetAllTasksAsync()` - Obtener todas las tareas
- [ ] `CreateTaskAsync()` - Crear nueva tarea
- [ ] `UpdateTaskAsync()` - Actualizar tarea
- [ ] `CompleteTaskAsync()` - Marcar como completada

#### 4. **Controllers** (Prioridad Media)
- [ ] Implementar endpoints en `UsersController`
- [ ] Implementar endpoints en `AuthController`
- [ ] Implementar endpoints en `TasksController`
- [ ] Agregar validaciones y manejo de errores

### 💡 Tips para Estudiantes

1. **Revisar comentarios TODO** - Cada archivo tiene instrucciones detalladas
2. **Seguir el patrón establecido** - Usar `ApiResponse<T>` para respuestas
3. **Manejar errores apropiadamente** - Try-catch en todos los métodos
4. **Usar async/await** - Para operaciones de base de datos
5. **Probar con Swagger** - Verificar cada endpoint implementado

## 🔧 Configuración de Desarrollo

### Connection String
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:servidor-clase-web-dev.database.windows.net,1433;Initial Catalog=DesarrolloWebDb;..."
  }
}
```

### JWT Settings
```json
{
  "JwtSettings": {
    "SecretKey": "DevWorkshop-TaskAPI-SuperSecretKey-2025-ForEducationalPurposes",
    "Issuer": "DevWorkshop.TaskAPI",
    "Audience": "DevWorkshop.TaskAPI.Users",
    "ExpirationInMinutes": 60
  }
}
```

## 🐛 Solución de Problemas

### Errores Comunes

1. **Error de conexión a BD**: Verificar que la cadena de conexión sea correcta
2. **Errores de compilación**: Asegurar que todas las dependencias estén instaladas
3. **Errores de JWT**: Verificar configuración en `appsettings.json`

### Comandos Útiles

```bash
# Limpiar y reconstruir
dotnet clean && dotnet build

# Ver logs detallados
dotnet run --project DevWorkshop.TaskAPI.Api --verbosity detailed

# Verificar paquetes
dotnet list package
```

## 📞 Soporte

**Instructor:** DevWorkshop Team  
**Email:** admin@devworkshop.com  
**Proyecto:** Taller de Desarrollo Web con .NET 9

---

## 🎉 ¡Comienza el Taller!

1. Ejecuta la API
2. Abre Swagger en tu navegador
3. Prueba el endpoint `/api/workshop/info`
4. Revisa las tareas en `/api/workshop/tasks`
5. ¡Comienza a implementar!

**¡Buena suerte y feliz codificación! 🚀**
