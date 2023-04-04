using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public abstract class BaseDAL
    {
        private string _connectionString = "Server=mssqlstud.fhict.local;Database=dbi507161_s2beamersh;User Id=dbi507161_s2beamersh;Password=beamershop123;";

        protected IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            return connection;
        }
    }

}