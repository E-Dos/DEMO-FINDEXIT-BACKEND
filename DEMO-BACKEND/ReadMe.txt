1) Use 'EntityFramework6\Add-Migration' for Entity Framework 7
2) EntityFrameworkCore\Add-Migration
3) To undo this action, use Remove-Migration
4) EntityFrameworkCore\Update-Database
5) dotnet ef migrations script --project "TEMPLATE-ELDOS-BACKEND" --context "AppDbContext" --output MigrationScript.sql --idempotent

1) dotnet restore (restore packages of current directory)
2) dotnet publish -c Release --output "C:\inetpub\wwwroot\LearnCert\Backend" LearnCert.sln (publish Solution)
3) dotnet publish -c Release --output "C:\inetpub\wwwroot\LearnCert\Backend" LearnCertBackEnd\Backend.csproj (publish csproj file)