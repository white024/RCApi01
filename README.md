# RCApi01 Install

RCAndroidWebApi

# tools
dotnet tool install -g dotnet-aspnet-codegenerator

Install-Package Microsoft.EntityFrameworkCore

Install-Package Microsoft.EntityFrameworkCore.Design

Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.SqlServer

Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

# conn string
Server=localhost;Database=master;Trusted_Connection=True;


# create asp.net core web app (model-view-controller)
    

# edit appsettings.json
"AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "SERVER=MONSTER_ABRA_A5;Database=RC;Trusted_Connection=True;"
  }
  
# edit program.cs (startup.cs for netcore 5)
builder.Services.AddDbContext<RCContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
