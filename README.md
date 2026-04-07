# The Project APIASPDOTNETMSSQLServer-dev      
A .Net SDK 8.0 to use with C# API Web ASP.NET Core and SQL Server     
- Dockerfile Container and Docker Compose      
           
## Application with minimum code             
No migration, for now only dotnet build and dotnet run.        
I will use DBeaver, how to connect with SQL Server.               
        
### Complete project structure      
APIASPDOTNETMSSQLServer-dev/      
├── API/      
│   ├── API.csproj      
│   ├── Program.cs      
│   ├── appsettings.json      
│   └── Dockerfile      
├── docker-compose.yml      
├── .gitignore      
└── .dockerignore       
      
       
### Commands      
#### Build & start      
docker compose up -d --build      
      
#### View logs      
docker compose logs -f      
      
#### Stop      
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
               