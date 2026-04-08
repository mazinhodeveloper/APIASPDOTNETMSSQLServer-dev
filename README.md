# The Project APIASPDOTNETMSSQLServer-dev      
A .Net SDK 8.0 to use with C# API Web ASP.NET Core and SQL Server     
- Dockerfile Container and Docker Compose      
           
## Application with minimum code             
No migration, for now only dotnet build and dotnet run.        
I will use DBeaver, how to connect with SQL Server.               
        
### Complete project structure            
APIASPDOTNETMSSQLServer-dev/          
├── API/          
│   ├── Controllers/          
│   │   └── ACLController.cs          
│   ├── Repositories/          
│   │   └── RepositoryACL.cs           
│   ├── Data/          
│   │   └── Models/          
│   │       └── ACL.cs          
│   ├── Models/          
│   │   └── ACLRequestModel.cs          
│   ├── Properties/          
│   │   └── launchSettings.json          
│   ├── API.csproj          
│   ├── Program.cs          
│   ├── appsettings.json          
│   └── Dockerfile          
├── docker-compose.yml          
├── .env          
├── .gitignore          
└── .dockerignore               
                 
### Commands to add NuGet package      
dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 8.0.0    
dotnet add package Microsoft.Data.SqlClient --version 8.0.0           
dotnet add package Swashbuckle.AspNetCore --version 8.0.0             
dotnet add package Dapper --version 8.0.0            
     
#### Build & start      
docker compose up -d --build          
     
#### Build & start ignores all cached layers      
docker compose build --no-cache; docker compose up -d  
      
#### Stop api & build & start api        
docker compose stop api; docker compose up -d --build api      
       
#### View logs      
docker compose logs -f      
      
#### Stop & remove      
docker compose down      
      
#### Stop & remove volumes      
docker compose down -v      
      
#### Enter API container      
docker exec -it api-dev bash      
      
#### Enter SQL Server container      
docker exec -it mssql-dev bash      
      

### DBeaver Connection Settings            
| Setting | Value |             
|---------|-------|              
| **Host** | `localhost` |              
| **Port** | `1433` |               
| **Database** | `master` |            
| **Username** | `sa` |             
| **Password** | `YourStrong@Passw0rd` |            
| **Driver** | SQL Server (Microsoft) |            
            
#### Steps:     
Open DBeaver → New Database Connection            
Select SQL Server            
Fill the settings above            
Click Test Connection (driver will download if needed)            
Click Finish               
                     
##### Important:      
Uncheck "Use SSL" or enable "Trust Server Certificate" in connection settings            
In DBeaver: Connection → Edit → SSL tab → Set "SSL Mode" to DISABLE or in Driver properties add encrypt=false            
             
                  
### Test Endpoints                        
#### Health check                     
curl http://localhost:8080/health                     

#### DB connection test                     
curl http://localhost:8080/db/test                     

#### Swagger UI                     
##### Open browser        
http://localhost:8080/swagger                         

#### Endpoint                     
##### Open browser        
http://localhost:8080/api/acl          
http://localhost:8080/api/acl/4         

               