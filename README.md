# Proyecto Factoring - .NET Core 6 + Entity Framework Core + MySQL

Este proyecto está desarrollado en **C# (versión 6.0)** con **.NET Core 6.0** y utiliza **Entity Framework Core** como ORM para manejar la persistencia de datos en una base de datos **MySQL**.

---

## 📦 Paquetes instalados

Los paquetes principales utilizados son:

- `Microsoft.EntityFrameworkCore.Design (6.0.0)`
- `Microsoft.EntityFrameworkCore.Tools (6.0.0)`
- `Pomelo.EntityFrameworkCore.MySql (6.0.0)` → Proveedor de MySQL para EF Core.
- `Swashbuckle.AspNetCore (6.5.0)` → Para documentación de API con **Swagger**.

---

## ⚙️ Configuración de la base de datos

En el archivo **`appsettings.json`**, la cadena de conexión está configurada de la siguiente manera:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=127.0.0.1;Database=proyectofactoring;User ID=root;Password=root"
}
