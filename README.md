<h1 align="center" id="title">(3) ASP.NET Core MVC CRUD - .NET 6 MVC CRUD Operations Using Entity Framework Core and SQL Server</h1>

## Tutorial
[![ASP.NET Core MVC CRUD - .NET 6 MVC CRUD Operations Using Entity Framework Core and SQL Server](https://img.youtube.com/vi/2Cp8Ti_f9Gk/0.jpg)](https://www.youtube.com/watch?v=2Cp8Ti_f9Gk)


## Getting Started
### 1. Inititalize Project
- Create a <b>ASP.NET Core Web App (Model-View-Controller)</b> project

### 2.  Install Dependencies
Open the "Package Manager Console" in Visual Studio (Tools > Nuget Package Manager > Package Manager Console) and install
- [Microsoft.EntityFrameworkCore.SqlServer]([https://link-url-here.org](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/))
  ```NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer ```
- Microsoft.EntityFrameworkCore.Tools
  ``` Install-Package Microsoft.EntityFrameworkCore.Tools ```

### 3. Create DB Context
- Create "Data" folder
- Create "MVCDemoDbContext.cs" in the folder
  ```
  // the code should be like this:
  using Microsoft.EntityFrameworkCore;
  
  namespace mvc_crud_with_dotnet_core.Data
  {
  	public class MVCDemoDbContext : DbContext
  	{
  	}
  }
  ```
- Create constructor ( shortcut: ctrl + . then select constructor with parameter )
  ```
  // the code should be like this:
  using Microsoft.EntityFrameworkCore;
  
  namespace mvc_crud_with_dotnet_core.Data
  {
  	public class MVCDemoDbContext : DbContext
  	{
  		public MVCDemoDbContext(DbContextOptions options) : base(options)
  		{
  		}
  	}
  }
  ```

### 4. Database Connection
- Create connection string in appsettings.json
  ```
    "ConnectionStrings": {
      "MvcDemoCOnnectionString": "server=LAPTOP-JP6QO1OQ\\SQLEXPRESS;database=mvcdemo;Trusted_connection=true;TrustServerCertificate=true"
    }
  ```
- In Program.cs, configure connection
  ```
  builder.Services.AddDbContext<MVCDemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MvcDemoConnectionString")));
  ```

### 5. Create Model
- Create "Domain" folder
- Create main "model" class in the folder and its properties ( shortkey: prop )
  ```
  // for example
  namespace mvc_crud_with_dotnet_core.Models.Domain
  {
  	public class Employee
  	{
  		public Guid Id { get; set; }
  
  		public string Name { get; set; }
  
  		public string Email { get; set; }
  
  		public long Salary { get; set; }
  
  		public DateTime DateOfBirth { get; set; }
  		
  		public int Department { get; set; }
  	}
  }
  ```
- Using the model in "MVCDemoDbContext" file
  ```
  using Microsoft.EntityFrameworkCore;
  using mvc_crud_with_dotnet_core.Models.Domain;
  
  namespace mvc_crud_with_dotnet_core.Data
  {
  	public class MVCDemoDbContext : DbContext
  	{
  		public MVCDemoDbContext(DbContextOptions options) : base(options)
  		{
  		}
  
          // HERE!!!
          public DbSet<Employee> Employees { get; set; }
      }
  }
  ```
- Inject DB context in services
  ``` 
  builder.Services.AddDbContext<MVCDemoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MvcDemoConnectionString")));
  ```
  
### 6. Run Migrations
Open the "Package Manager Console" in Visual Studio (Tools > Nuget Package Manager > Package Manager Console), run
```
Add-Migration "name of migration
Update-Database
```

### 7. Create Controller
- Right click "Controllers" folder, select "Add", then "Controller"
- Choose MVC Controller Empty and name the file

### 8. Create CRUD Operation
- Right click "Model" folder, Add "AddNameViewModel.cs" and "UpdateNameViewModel.cs" for create and update function
- In controller, right click the <b>View()</b> to add View
- View the code
