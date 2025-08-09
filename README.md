# 🛠️ DevWorkshop-TaskAPI

[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-9.0.7-green.svg)](https://docs.microsoft.com/en-us/ef/)
[![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-orange.svg)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

Plantilla educativa de API REST con **.NET 9** y **Clean Architecture**. Incluye patrones Repository/Unit of Work, Entity Framework Core y TODOs estructurados para estudiantes.

## 🎯 Características

- **Clean Architecture** (Domain, Application, Infrastructure, API)
- **Repository & Unit of Work** patterns
- **Entity Framework Core** + SQL Server
- **AutoMapper** + **Swagger/OpenAPI**
- **URLs descriptivas** (`/api/roles/getAll`, `/api/users/create`)
- **RolesController** completamente implementado (ejemplo)
- **TODOs** para Users, Tasks y Auth (práctica)

## 🏗️ Estructura

```
📁 DevWorkshop-TaskAPI/
├── 📁 Domain/          # Entidades y reglas de negocio
├── 📁 Application/     # DTOs, servicios e interfaces
├── 📁 Infrastructure/  # EF Core, Repositories, Unit of Work
└── 📁 Api/             # Controladores y configuración
```

## 🚀 Instalación

**Prerrequisitos**: [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) + [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)

```bash
# 1. Clonar o usar template
git clone https://github.com/JohanCalaT/DevWorkshop-TaskAPI.git
cd DevWorkshop-TaskAPI

# 2. Configurar BD en appsettings.json
# "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskFlowProDB;Trusted_Connection=true"

# 3. Crear BD
dotnet ef database update --project DevWorkshop.TaskAPI.Infrastructure --startup-project DevWorkshop.TaskAPI.Api

# 4. Ejecutar
dotnet run --project DevWorkshop.TaskAPI.Api

# 5. Probar: https://localhost:7000/swagger
```

## 📚 Endpoints

### **🎭 Roles ✅ IMPLEMENTADO**
- `GET /api/roles/getAll` - Obtener todos
- `GET /api/roles/getById/{id}` - Obtener por ID
- `GET /api/roles/getStatistics` - Estadísticas
- `POST /api/roles/create` - Crear (TODO)
- `PUT /api/roles/update/{id}` - Actualizar (TODO)
- `DELETE /api/roles/delete/{id}` - Eliminar (TODO)

### **👥 Usuarios 📝 TODO**
- `GET /api/users/getAll` - Obtener todos
- `POST /api/users/create` - Crear usuario
- `PUT /api/users/update/{id}` - Actualizar
- `DELETE /api/users/delete/{id}` - Eliminar

### **📋 Tareas 📝 TODO**
- `GET /api/tasks/getAll` - Obtener todas
- `POST /api/tasks/create` - Crear tarea
- `PUT /api/tasks/update/{id}` - Actualizar
- `DELETE /api/tasks/delete/{id}` - Eliminar

### **🔐 Auth 📝 TODO**
- `POST /api/auth/login` - Login
- `POST /api/auth/register` - Registro

## 🎓 Para Estudiantes

1. **Estudiar** `RolesController` (ejemplo completo)
2. **Buscar** comentarios `// TODO: ESTUDIANTE`
3. **Implementar** siguiendo el mismo patrón

### **Pasos para nuevo endpoint:**
1. DTOs en `Application/DTOs/`
2. Interfaz en `Application/Interfaces/`
3. Servicio en `Application/Services/`
4. Controlador en `Api/Controllers/`
5. Registrar en `Program.cs`

## 🚨 Problemas Comunes

```bash
# Error de BD
dotnet ef database drop --force
dotnet ef database update

# Error de migraciones
dotnet ef migrations remove --force
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 📚 Recursos

- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

---

**¿Necesitas ayuda?** Abre un [issue](https://github.com/JohanCalaT/DevWorkshop-TaskAPI/issues)

**¿Te gusta el proyecto?** ¡Dale una ⭐!
