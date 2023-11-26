# RCApi01 Install

RCAndroidWebApi

# tools for net core 6

dotnet tool install -g dotnet-aspnet-codegenerator --Version 6.0.10

Install-Package Microsoft.EntityFrameworkCore -Version 6.0.10

Install-Package Microsoft.EntityFrameworkCore.Design -Version 6.0.10

Install-Package Microsoft.EntityFrameworkCore.Tools -Version 6.0.10

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 6.0.10

Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.10

dotnet tool install --global dotnet-ef --Version 6.0.10

# tools for net core 3
dotnet tool install -g dotnet-aspnet-codegenerator --version 3.1.0

Install-Package Microsoft.EntityFrameworkCore -Version 3.1.0

Install-Package Microsoft.EntityFrameworkCore.Design -Version 3.1.0

Install-Package Microsoft.EntityFrameworkCore.Tools -Version 3.1.0

Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.0

Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 3.1.0

dotnet tool install --global dotnet-ef --version 3.1.0


# conn string
Server=localhost;Database=master;Trusted_Connection=True;


# create asp.net core web app (model-view-controller)
    

# edit appsettings.json
"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "SERVER=MONSTER_ABRA_A5;Database=RC;Trusted_Connection=True;"
  }
  
# edit program.cs for Netcore 6
"builder.Services.AddDbContext<yourcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));"
# For Netcore old verisions edit startup.cs
"Services.AddDbContext<yourcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));"


# create models example
dotnet ef dbcontext scaffold "SERVER=MONSTER_ABRA_A5;Database=RC;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models


# create controller example
dotnet aspnet-codegenerator controller -name Yonetici -async -api -m YoneticiGiris -dc RCContext -outDir Controllers

dotnet aspnet-codegenerator controller -name RCController -async -api -m RC -dc RCContext -outDir Controllers 


# for update add -f commands 
# Update models example
dotnet ef dbcontext scaffold "SERVER=MONSTER_ABRA_A5;Database=RC;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f


# Updatecontrollers example
dotnet aspnet-codegenerator controller -name kullanici -async -api -m KullaniciList -dc RCContext -outDir Controllers -f


# and optional IP configs etc.
