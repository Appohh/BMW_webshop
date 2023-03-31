using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace Data
{
    public class DataHandler : BaseDAL
    {
        private readonly IDbConnection con;
        protected virtual string? Cmd { get; }
        
        public DataHandler()
        {
            con = base.GetConnection();
        }

        public DataTable? ReadData([Optional] string query) //read
        {
            DataTable result = new DataTable();
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
                    //get command
                    if (query != null)
                    {
                        command.CommandText = query;
                    }
                    else
                    {
                        command.CommandText = this.Cmd;
                    }
                    //get data
                    var data = command.ExecuteReader();
                    //fill datatable with querried data
                    result.Load(data);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public int executeQuery(string query)
        {
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
                    command.CommandText = query;
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int executeIdScalar(string query)
        {
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
                    command.CommandText = query;
                    int newId = (int)command.ExecuteScalar();

                    return newId;
                }
            }
            catch
            {
                return 0;
            }
            finally { 
                con.Close(); 
            }
        }

    }
}

