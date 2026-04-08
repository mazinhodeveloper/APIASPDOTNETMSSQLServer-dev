using Dapper; // Ensure you have Dapper installed via NuGet
using APIASPDOTNETMSSQLServer.Data.Models;
using APIASPDOTNETMSSQLServer.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace APIASPDOTNETMSSQLServer.Repositories
{
    public class RepositoryACL
    {
        private readonly string _connectionString;

        public RepositoryACL(IConfiguration configuration)
        {
            // Gets the connection string defined in appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // READ: Get all ACLs
        public async Task<IEnumerable<ACL>> GetAllAsync()
        {
            using (var db = CreateConnection())
            {
                return await db.QueryAsync<ACL>("SELECT * FROM ztACL ORDER BY idACL");
            }
        }

        // READ: Get ACL by ID
        public async Task<ACL> GetByIdAsync(int id)
        {
            using (var db = CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<ACL>("SELECT * FROM ztACL WHERE idACL = @Id", new { Id = id });
            }
        }

        // CREATE: Insert new ACL
        public async Task<int> AddAsync(ACL acl)
        {
            using (var db = CreateConnection())
            {
                var sql = "INSERT INTO ztACL (tipo, descricao) VALUES (@Tipo, @Descricao); SELECT CAST(SCOPE_IDENTITY() as int);";
                return await db.QuerySingleAsync<int>(sql, acl);
            }
        }

        // UPDATE: Modify existing ACL
        public async Task<bool> UpdateAsync(ACL acl)
        {
            using (var db = CreateConnection())
            {
                var sql = "UPDATE ztACL SET tipo = @Tipo, descricao = @Descricao WHERE idACL = @IdACL";
                var rowsAffected = await db.ExecuteAsync(sql, acl);
                return rowsAffected > 0;
            }
        }

        // DELETE: Remove ACL
        public async Task<bool> DeleteAsync(int id)
        {
            using (var db = CreateConnection())
            {
                var sql = "DELETE FROM ztACL WHERE idACL = @Id";
                var rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
