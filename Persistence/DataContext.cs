using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class DataContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
    
    public IDbConnection CreateMasterConnection()
        => new SqlConnection(_configuration.GetConnectionString("MasterConnection"));

}